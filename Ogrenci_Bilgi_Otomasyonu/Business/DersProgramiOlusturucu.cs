using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ogrenci_Bilgi_Otomasyonu.Entity;

namespace Ogrenci_Bilgi_Otomasyonu.Business
{
    public class DersProgramiOlusturucu
    {
        private readonly DersManager _dersManager = new DersManager();
        private readonly SinifManager _sinifManager = new SinifManager();
        private readonly OgretmenManager _ogretmenManager = new OgretmenManager();

        // 5 ders saati (kullanıcı isteğine göre)
        private readonly string[] _saatler = { "08:30-09:10", "09:20-10:00", "10:10-10:50", "11:00-11:40", "12:30-13:10" };
        private readonly string[] _gunler = { "Pazartesi", "Salı", "Çarşamba", "Perşembe", "Cuma" };

        // Öğretmen meşguliyet takibi
        private HashSet<string> _ogretmenMesgul = new HashSet<string>();

        public List<DersProgrami> ProgramOlustur()
        {
            return YerelProgramOlustur();
        }

        public List<DersProgrami> YerelProgramOlustur()
        {
            var sonuc = new List<DersProgrami>();
            _ogretmenMesgul.Clear();

            var siniflar = _sinifManager.SinifListesiGetir();
            var tumDersler = _dersManager.TumDersleriGetir();

            // Öğretmeni olan dersleri al
            var dersListesi = new List<DersDetay>();
            foreach (DataRow row in tumDersler.Rows)
            {
                object ogretmenIdObj = row["OgretmenID"];
                if (ogretmenIdObj == null || ogretmenIdObj == DBNull.Value) continue;

                dersListesi.Add(new DersDetay
                {
                    DersId = Convert.ToInt32(row["DersID"]),
                    DersAdi = row["DersAdi"].ToString(),
                    OgretmenId = Convert.ToInt32(ogretmenIdObj),
                    HaftalikSaat = Convert.ToInt32(row["HaftalikSaat"])
                });
            }

            if (dersListesi.Count == 0) return sonuc;

            // Her sınıf için program oluştur
            foreach (DataRow sinifRow in siniflar.Rows)
            {
                int sinifId = Convert.ToInt32(sinifRow["SinifID"]);
                var sinifProgrami = SinifProgramiOlustur(sinifId, dersListesi);
                sonuc.AddRange(sinifProgrami);
            }

            return sonuc;
        }

        private List<DersProgrami> SinifProgramiOlustur(int sinifId, List<DersDetay> tumDersler)
        {
            var program = new List<DersProgrami>();
            var random = new Random(sinifId * 1000 + DateTime.Now.Second);

            // Bu sınıf için kullanılan slotlar
            var sinifSlotlari = new HashSet<string>();

            // Her gün 5 ders = toplam 25 slot
            int toplamSlot = _gunler.Length * _saatler.Length; // 5 x 5 = 25

            // Dersleri haftalık saatlerine göre çoğalt ve karıştır
            var dersHavuzu = new List<DersDetay>();
            foreach (var ders in tumDersler)
            {
                for (int i = 0; i < ders.HaftalikSaat; i++)
                {
                    dersHavuzu.Add(ders);
                }
            }

            // Havuzu karıştır
            dersHavuzu = dersHavuzu.OrderBy(x => random.Next()).ToList();

            // Eğer yeterli ders yoksa, döngüsel olarak tekrarla
            int dersIndex = 0;

            // Her slot için ders yerleştir
            foreach (var gun in _gunler)
            {
                for (int saatIdx = 0; saatIdx < _saatler.Length; saatIdx++)
                {
                    string slotKey = sinifId + "_" + gun + "_" + saatIdx;
                    if (sinifSlotlari.Contains(slotKey)) continue;

                    // Uygun ders bul
                    DersDetay secilenDers = null;
                    int deneme = 0;
                    int maxDeneme = dersHavuzu.Count * 2;

                    while (secilenDers == null && deneme < maxDeneme)
                    {
                        var aday = dersHavuzu[dersIndex % dersHavuzu.Count];
                        string ogretmenSlot = aday.OgretmenId + "_" + gun + "_" + saatIdx;

                        // Öğretmen müsait mi?
                        if (!_ogretmenMesgul.Contains(ogretmenSlot))
                        {
                            secilenDers = aday;
                        }

                        dersIndex++;
                        deneme++;
                    }

                    // Ders bulunamadıysa herhangi bir ders seç (öğretmen çakışmasını göz ardı et)
                    if (secilenDers == null && dersHavuzu.Count > 0)
                    {
                        secilenDers = dersHavuzu[random.Next(dersHavuzu.Count)];
                    }

                    if (secilenDers != null)
                    {
                        string[] saatParts = _saatler[saatIdx].Split('-');
                        TimeSpan baslangic = TimeSpan.Parse(saatParts[0]);
                        TimeSpan bitis = TimeSpan.Parse(saatParts[1]);

                        program.Add(new DersProgrami
                        {
                            SinifID = sinifId,
                            DersID = secilenDers.DersId,
                            OgretmenID = secilenDers.OgretmenId,
                            Gun = gun,
                            DersSaati = saatIdx + 1,
                            BaslangicSaati = baslangic,
                            BitisSaati = bitis,
                            Durum = true
                        });

                        sinifSlotlari.Add(slotKey);
                        string ogretmenSlotKey = secilenDers.OgretmenId + "_" + gun + "_" + saatIdx;
                        _ogretmenMesgul.Add(ogretmenSlotKey);
                    }
                }
            }

            return program;
        }

        private class DersDetay
        {
            public int DersId { get; set; }
            public string DersAdi { get; set; }
            public int OgretmenId { get; set; }
            public int HaftalikSaat { get; set; }
        }

        public List<string> CakismaKontrol(List<DersProgrami> program)
        {
            var cakismalar = new List<string>();
            var ogretmenSlotlari = new Dictionary<string, DersProgrami>();

            foreach (var ders in program)
            {
                string key = ders.OgretmenID + "_" + ders.Gun + "_" + ders.DersSaati;
                if (ogretmenSlotlari.ContainsKey(key))
                {
                    var mevcut = ogretmenSlotlari[key];
                    cakismalar.Add("ÇAKIŞMA: Öğretmen " + ders.OgretmenID + " - " + ders.Gun + " " + ders.DersSaati + ". ders");
                }
                else
                {
                    ogretmenSlotlari[key] = ders;
                }
            }

            return cakismalar;
        }

        public async Task<string> TestApiConnection(string provider, string apiKey)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    if (provider == "Google Gemini")
                    {
                        var url = "https://generativelanguage.googleapis.com/v1beta/models/gemini-2.0-flash:generateContent?key=" + apiKey;
                        var requestBody = new GeminiRequest { contents = new List<GeminiContent> { new GeminiContent { parts = new List<GeminiPart> { new GeminiPart { text = "Hello" } } } } };
                        var json = Serialize(requestBody);
                        var response = await client.PostAsync(url, new StringContent(json, Encoding.UTF8, "application/json"));
                        
                        if (response.IsSuccessStatusCode) return "Bağlantı Başarılı!";
                        return "Hata: " + response.StatusCode;
                    }
                    return "Geçersiz Sağlayıcı";
                }
            }
            catch (Exception ex)
            {
                return "Hata: " + ex.Message;
            }
        }

        public async Task<Tuple<string, List<DersProgrami>>> ApiIleProgramOlusturVeGetirAsync()
        {
            return new Tuple<string, List<DersProgrami>>("Yerel algoritma kullanıldı.", YerelProgramOlustur());
        }

        private Tuple<string, string> AyarlariOku()
        {
            string key = "", provider = "";
            var path = Path.Combine(Application.StartupPath, "ayarlar.config");
            if (File.Exists(path))
            {
                foreach (var line in File.ReadAllLines(path))
                {
                    var parts = line.Split('=');
                    if (parts.Length == 2)
                    {
                        if (parts[0].Trim() == "ApiKey") key = parts[1].Trim();
                        else if (parts[0].Trim() == "ApiProvider") provider = parts[1].Trim();
                    }
                }
            }
            return new Tuple<string, string>(key, provider);
        }

        private string Serialize<T>(T obj)
        {
            using (var ms = new MemoryStream())
            {
                var ser = new DataContractJsonSerializer(typeof(T));
                ser.WriteObject(ms, obj);
                return Encoding.UTF8.GetString(ms.ToArray());
            }
        }

        private T Deserialize<T>(string json)
        {
            using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(json)))
            {
                var ser = new DataContractJsonSerializer(typeof(T));
                return (T)ser.ReadObject(ms);
            }
        }

        [DataContract] class GeminiRequest { [DataMember] public List<GeminiContent> contents { get; set; } }
        [DataContract] class GeminiContent { [DataMember] public List<GeminiPart> parts { get; set; } }
        [DataContract] class GeminiPart { [DataMember] public string text { get; set; } }
    }
}
