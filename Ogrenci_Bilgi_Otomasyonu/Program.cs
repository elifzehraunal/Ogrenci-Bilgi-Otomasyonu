using System;
using System.Windows.Forms;
using DevExpress.LookAndFeel;
using DevExpress.Skins;
using DevExpress.Utils;
using Ogrenci_Bilgi_Otomasyonu.UI;

namespace Ogrenci_Bilgi_Otomasyonu
{
    internal static class Program
    {
        /// <summary>
        /// Uygulamanın ana girdi noktası.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Modern Koyu Tema
            UserLookAndFeel.Default.SetSkinStyle("DevExpress Dark Style");
            
            // Form Skinleri Etkinleştir
            SkinManager.EnableFormSkins();
            SkinManager.EnableMdiFormSkins();
            
            // Varsayılan font ayarları
            AppearanceObject.DefaultFont = new System.Drawing.Font("Segoe UI", 9.5f);

            // Giriş formunu başlat
            Application.Run(new FrmGiris());
        }
    }
}
