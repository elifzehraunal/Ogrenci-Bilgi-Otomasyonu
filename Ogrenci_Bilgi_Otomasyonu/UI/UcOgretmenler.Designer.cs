namespace Ogrenci_Bilgi_Otomasyonu.UI
{
    partial class UcOgretmenler
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing) { if (disposing && (components != null)) { components.Dispose(); } base.Dispose(disposing); }

        #region Component Designer generated code
        private void InitializeComponent()
        {
            this.pnlHeader = new DevExpress.XtraEditors.PanelControl();
            this.lblBaslik = new DevExpress.XtraEditors.LabelControl();
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.groupControl = new DevExpress.XtraEditors.GroupControl();
            this.btnSil = new DevExpress.XtraEditors.SimpleButton();
            this.btnKaydet = new DevExpress.XtraEditors.SimpleButton();
            this.btnYeni = new DevExpress.XtraEditors.SimpleButton();
            this.txtEmail = new DevExpress.XtraEditors.TextEdit();
            this.txtTelefon = new DevExpress.XtraEditors.TextEdit();
            this.cmbCinsiyet = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cmbBrans = new DevExpress.XtraEditors.ComboBoxEdit();
            this.txtTC = new DevExpress.XtraEditors.TextEdit();
            this.txtSoyad = new DevExpress.XtraEditors.TextEdit();
            this.txtAd = new DevExpress.XtraEditors.TextEdit();
            this.lbl1 = new DevExpress.XtraEditors.LabelControl();
            this.lbl2 = new DevExpress.XtraEditors.LabelControl();
            this.lbl3 = new DevExpress.XtraEditors.LabelControl();
            this.lbl4 = new DevExpress.XtraEditors.LabelControl();
            this.lbl5 = new DevExpress.XtraEditors.LabelControl();
            this.lbl6 = new DevExpress.XtraEditors.LabelControl();
            this.lbl7 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.pnlHeader)).BeginInit();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl)).BeginInit();
            this.groupControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmail.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTelefon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbCinsiyet.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbBrans.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTC.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoyad.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAd.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.Appearance.BackColor = System.Drawing.Color.FromArgb(255, 112, 67);
            this.pnlHeader.Appearance.Options.UseBackColor = true;
            this.pnlHeader.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlHeader.Controls.Add(this.lblBaslik);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(900, 50);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblBaslik
            // 
            this.lblBaslik.Appearance.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblBaslik.Appearance.ForeColor = System.Drawing.Color.White;
            this.lblBaslik.Appearance.Options.UseFont = true;
            this.lblBaslik.Appearance.Options.UseForeColor = true;
            this.lblBaslik.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblBaslik.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblBaslik.Location = new System.Drawing.Point(0, 0);
            this.lblBaslik.Name = "lblBaslik";
            this.lblBaslik.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.lblBaslik.Size = new System.Drawing.Size(900, 50);
            this.lblBaslik.TabIndex = 0;
            this.lblBaslik.Text = "👨‍🏫 ÖĞRETMEN YÖNETİMİ";
            // 
            // gridControl
            // 
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.Location = new System.Drawing.Point(0, 50);
            this.gridControl.MainView = this.gridView;
            this.gridControl.Name = "gridControl";
            this.gridControl.Size = new System.Drawing.Size(550, 550);
            this.gridControl.TabIndex = 1;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { this.gridView });
            // 
            // gridView
            // 
            this.gridView.GridControl = this.gridControl;
            this.gridView.Name = "gridView";
            this.gridView.OptionsBehavior.Editable = false;
            this.gridView.OptionsView.ShowGroupPanel = false;
            this.gridView.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView_FocusedRowChanged);
            // 
            // groupControl
            // 
            this.groupControl.AppearanceCaption.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.groupControl.AppearanceCaption.Options.UseFont = true;
            this.groupControl.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupControl.Location = new System.Drawing.Point(550, 50);
            this.groupControl.Name = "groupControl";
            this.groupControl.Size = new System.Drawing.Size(350, 550);
            this.groupControl.TabIndex = 2;
            this.groupControl.Text = "Öğretmen Bilgileri";
            // lbl1
            this.lbl1.Location = new System.Drawing.Point(15, 35); this.lbl1.Name = "lbl1"; this.lbl1.Text = "Ad:";
            // txtAd
            this.txtAd.Location = new System.Drawing.Point(100, 32); this.txtAd.Name = "txtAd"; this.txtAd.Size = new System.Drawing.Size(230, 20);
            // lbl2
            this.lbl2.Location = new System.Drawing.Point(15, 70); this.lbl2.Name = "lbl2"; this.lbl2.Text = "Soyad:";
            // txtSoyad
            this.txtSoyad.Location = new System.Drawing.Point(100, 67); this.txtSoyad.Name = "txtSoyad"; this.txtSoyad.Size = new System.Drawing.Size(230, 20);
            // lbl3
            this.lbl3.Location = new System.Drawing.Point(15, 105); this.lbl3.Name = "lbl3"; this.lbl3.Text = "TC:";
            // txtTC
            this.txtTC.Location = new System.Drawing.Point(100, 102); this.txtTC.Name = "txtTC"; this.txtTC.Size = new System.Drawing.Size(230, 20);
            // lbl4
            this.lbl4.Location = new System.Drawing.Point(15, 140); this.lbl4.Name = "lbl4"; this.lbl4.Text = "Branş:";
            // cmbBrans
            this.cmbBrans.Location = new System.Drawing.Point(100, 137); this.cmbBrans.Name = "cmbBrans"; this.cmbBrans.Size = new System.Drawing.Size(230, 20);
            this.cmbBrans.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbBrans.Properties.Items.AddRange(new object[] {"Türkçe", "Matematik", "Fen Bilimleri", "Sosyal Bilgiler", "İngilizce", "Din Kültürü ve Ahlak Bilgisi", "Beden Eğitimi", "Müzik", "Görsel Sanatlar", "Bilişim Teknolojileri", "Teknoloji ve Tasarım"});
            // lbl5
            this.lbl5.Location = new System.Drawing.Point(15, 175); this.lbl5.Name = "lbl5"; this.lbl5.Text = "Cinsiyet:";
            // cmbCinsiyet
            this.cmbCinsiyet.Location = new System.Drawing.Point(100, 172); this.cmbCinsiyet.Name = "cmbCinsiyet"; this.cmbCinsiyet.Size = new System.Drawing.Size(230, 20);
            this.cmbCinsiyet.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbCinsiyet.Properties.Items.AddRange(new object[] {"Erkek", "Kadın"});
            // lbl6
            this.lbl6.Location = new System.Drawing.Point(15, 210); this.lbl6.Name = "lbl6"; this.lbl6.Text = "Telefon:";
            // txtTelefon
            this.txtTelefon.Location = new System.Drawing.Point(100, 207); this.txtTelefon.Name = "txtTelefon"; this.txtTelefon.Size = new System.Drawing.Size(230, 20);
            // lbl7
            this.lbl7.Location = new System.Drawing.Point(15, 245); this.lbl7.Name = "lbl7"; this.lbl7.Text = "E-Mail:";
            // txtEmail
            this.txtEmail.Location = new System.Drawing.Point(100, 242); this.txtEmail.Name = "txtEmail"; this.txtEmail.Size = new System.Drawing.Size(230, 20);
            // btnYeni
            this.btnYeni.Appearance.BackColor = System.Drawing.Color.FromArgb(52, 168, 83);
            this.btnYeni.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnYeni.Appearance.Options.UseBackColor = true;
            this.btnYeni.Appearance.Options.UseForeColor = true;
            this.btnYeni.Location = new System.Drawing.Point(15, 290);
            this.btnYeni.Name = "btnYeni";
            this.btnYeni.Size = new System.Drawing.Size(100, 35);
            this.btnYeni.Text = "Yeni";
            this.btnYeni.Click += new System.EventHandler(this.btnYeni_Click);
            // btnKaydet
            this.btnKaydet.Appearance.BackColor = System.Drawing.Color.FromArgb(66, 133, 244);
            this.btnKaydet.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnKaydet.Appearance.Options.UseBackColor = true;
            this.btnKaydet.Appearance.Options.UseForeColor = true;
            this.btnKaydet.Location = new System.Drawing.Point(120, 290);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(100, 35);
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // btnSil
            this.btnSil.Appearance.BackColor = System.Drawing.Color.FromArgb(234, 67, 53);
            this.btnSil.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnSil.Appearance.Options.UseBackColor = true;
            this.btnSil.Appearance.Options.UseForeColor = true;
            this.btnSil.Location = new System.Drawing.Point(225, 290);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(100, 35);
            this.btnSil.Text = "Sil";
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // groupControl Controls
            this.groupControl.Controls.Add(this.btnSil);
            this.groupControl.Controls.Add(this.btnKaydet);
            this.groupControl.Controls.Add(this.btnYeni);
            this.groupControl.Controls.Add(this.txtEmail);
            this.groupControl.Controls.Add(this.lbl7);
            this.groupControl.Controls.Add(this.txtTelefon);
            this.groupControl.Controls.Add(this.lbl6);
            this.groupControl.Controls.Add(this.cmbCinsiyet);
            this.groupControl.Controls.Add(this.lbl5);
            this.groupControl.Controls.Add(this.cmbBrans);
            this.groupControl.Controls.Add(this.lbl4);
            this.groupControl.Controls.Add(this.txtTC);
            this.groupControl.Controls.Add(this.lbl3);
            this.groupControl.Controls.Add(this.txtSoyad);
            this.groupControl.Controls.Add(this.lbl2);
            this.groupControl.Controls.Add(this.txtAd);
            this.groupControl.Controls.Add(this.lbl1);
            // 
            // UcOgretmenler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridControl);
            this.Controls.Add(this.groupControl);
            this.Controls.Add(this.pnlHeader);
            this.Name = "UcOgretmenler";
            this.Size = new System.Drawing.Size(900, 600);
            ((System.ComponentModel.ISupportInitialize)(this.pnlHeader)).EndInit();
            this.pnlHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl)).EndInit();
            this.groupControl.ResumeLayout(false);
            this.groupControl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmail.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTelefon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbCinsiyet.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbBrans.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTC.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoyad.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAd.Properties)).EndInit();
            this.ResumeLayout(false);
        }
        #endregion

        private DevExpress.XtraEditors.PanelControl pnlHeader;
        private DevExpress.XtraEditors.LabelControl lblBaslik;
        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraEditors.GroupControl groupControl;
        private DevExpress.XtraEditors.LabelControl lbl1, lbl2, lbl3, lbl4, lbl5, lbl6, lbl7;
        private DevExpress.XtraEditors.TextEdit txtAd, txtSoyad, txtTC, txtTelefon, txtEmail;
        private DevExpress.XtraEditors.ComboBoxEdit cmbBrans;
        private DevExpress.XtraEditors.ComboBoxEdit cmbCinsiyet;
        private DevExpress.XtraEditors.SimpleButton btnYeni, btnKaydet, btnSil;
    }
}
