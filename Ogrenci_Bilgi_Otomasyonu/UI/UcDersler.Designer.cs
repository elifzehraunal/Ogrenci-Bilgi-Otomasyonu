namespace Ogrenci_Bilgi_Otomasyonu.UI
{
    partial class UcDersler
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
            this.spnHaftalikSaat = new DevExpress.XtraEditors.SpinEdit();
            this.lueOgretmen = new DevExpress.XtraEditors.LookUpEdit();
            this.txtDersKodu = new DevExpress.XtraEditors.TextEdit();
            this.txtDersAdi = new DevExpress.XtraEditors.TextEdit();
            this.lbl1 = new DevExpress.XtraEditors.LabelControl();
            this.lbl2 = new DevExpress.XtraEditors.LabelControl();
            this.lbl3 = new DevExpress.XtraEditors.LabelControl();
            this.lbl4 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.pnlHeader)).BeginInit();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl)).BeginInit();
            this.groupControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spnHaftalikSaat.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueOgretmen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDersKodu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDersAdi.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.Appearance.BackColor = System.Drawing.Color.FromArgb(103, 58, 183);
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
            this.lblBaslik.Text = "📚 DERS YÖNETİMİ";
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
            this.groupControl.Controls.Add(this.btnSil);
            this.groupControl.Controls.Add(this.btnKaydet);
            this.groupControl.Controls.Add(this.btnYeni);
            this.groupControl.Controls.Add(this.spnHaftalikSaat);
            this.groupControl.Controls.Add(this.lbl4);
            this.groupControl.Controls.Add(this.lueOgretmen);
            this.groupControl.Controls.Add(this.lbl3);
            this.groupControl.Controls.Add(this.txtDersKodu);
            this.groupControl.Controls.Add(this.lbl2);
            this.groupControl.Controls.Add(this.txtDersAdi);
            this.groupControl.Controls.Add(this.lbl1);
            this.groupControl.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupControl.Location = new System.Drawing.Point(550, 50);
            this.groupControl.Name = "groupControl";
            this.groupControl.Size = new System.Drawing.Size(350, 550);
            this.groupControl.TabIndex = 2;
            this.groupControl.Text = "Ders Bilgileri";
            // 
            // lbl1
            // 
            this.lbl1.Location = new System.Drawing.Point(15, 40);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(50, 13);
            this.lbl1.TabIndex = 0;
            this.lbl1.Text = "Ders Adı:";
            // 
            // txtDersAdi
            // 
            this.txtDersAdi.Location = new System.Drawing.Point(110, 37);
            this.txtDersAdi.Name = "txtDersAdi";
            this.txtDersAdi.Size = new System.Drawing.Size(220, 20);
            this.txtDersAdi.TabIndex = 1;
            // 
            // lbl2
            // 
            this.lbl2.Location = new System.Drawing.Point(15, 80);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(55, 13);
            this.lbl2.TabIndex = 2;
            this.lbl2.Text = "Ders Kodu:";
            // 
            // txtDersKodu
            // 
            this.txtDersKodu.Location = new System.Drawing.Point(110, 77);
            this.txtDersKodu.Name = "txtDersKodu";
            this.txtDersKodu.Size = new System.Drawing.Size(220, 20);
            this.txtDersKodu.TabIndex = 3;
            // 
            // lbl3
            // 
            this.lbl3.Location = new System.Drawing.Point(15, 120);
            this.lbl3.Name = "lbl3";
            this.lbl3.Size = new System.Drawing.Size(52, 13);
            this.lbl3.TabIndex = 4;
            this.lbl3.Text = "Öğretmen:";
            // 
            // lueOgretmen
            // 
            this.lueOgretmen.Location = new System.Drawing.Point(110, 117);
            this.lueOgretmen.Name = "lueOgretmen";
            this.lueOgretmen.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueOgretmen.Size = new System.Drawing.Size(220, 20);
            this.lueOgretmen.TabIndex = 5;
            // 
            // lbl4
            // 
            this.lbl4.Location = new System.Drawing.Point(15, 160);
            this.lbl4.Name = "lbl4";
            this.lbl4.Size = new System.Drawing.Size(65, 13);
            this.lbl4.TabIndex = 6;
            this.lbl4.Text = "Haftalık Saat:";
            // 
            // spnHaftalikSaat
            // 
            this.spnHaftalikSaat.EditValue = new decimal(new int[] { 3, 0, 0, 0 });
            this.spnHaftalikSaat.Location = new System.Drawing.Point(110, 157);
            this.spnHaftalikSaat.Name = "spnHaftalikSaat";
            this.spnHaftalikSaat.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spnHaftalikSaat.Properties.MaxValue = new decimal(new int[] { 10, 0, 0, 0 });
            this.spnHaftalikSaat.Properties.MinValue = new decimal(new int[] { 1, 0, 0, 0 });
            this.spnHaftalikSaat.Size = new System.Drawing.Size(100, 20);
            this.spnHaftalikSaat.TabIndex = 7;
            // 
            // btnYeni
            // 
            this.btnYeni.Appearance.BackColor = System.Drawing.Color.FromArgb(52, 168, 83);
            this.btnYeni.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnYeni.Appearance.Options.UseBackColor = true;
            this.btnYeni.Appearance.Options.UseForeColor = true;
            this.btnYeni.Location = new System.Drawing.Point(15, 210);
            this.btnYeni.Name = "btnYeni";
            this.btnYeni.Size = new System.Drawing.Size(100, 35);
            this.btnYeni.TabIndex = 8;
            this.btnYeni.Text = "Yeni";
            this.btnYeni.Click += new System.EventHandler(this.btnYeni_Click);
            // 
            // btnKaydet
            // 
            this.btnKaydet.Appearance.BackColor = System.Drawing.Color.FromArgb(66, 133, 244);
            this.btnKaydet.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnKaydet.Appearance.Options.UseBackColor = true;
            this.btnKaydet.Appearance.Options.UseForeColor = true;
            this.btnKaydet.Location = new System.Drawing.Point(120, 210);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(100, 35);
            this.btnKaydet.TabIndex = 9;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // btnSil
            // 
            this.btnSil.Appearance.BackColor = System.Drawing.Color.FromArgb(234, 67, 53);
            this.btnSil.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnSil.Appearance.Options.UseBackColor = true;
            this.btnSil.Appearance.Options.UseForeColor = true;
            this.btnSil.Location = new System.Drawing.Point(225, 210);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(100, 35);
            this.btnSil.TabIndex = 10;
            this.btnSil.Text = "Sil";
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // UcDersler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridControl);
            this.Controls.Add(this.groupControl);
            this.Controls.Add(this.pnlHeader);
            this.Name = "UcDersler";
            this.Size = new System.Drawing.Size(900, 600);
            ((System.ComponentModel.ISupportInitialize)(this.pnlHeader)).EndInit();
            this.pnlHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl)).EndInit();
            this.groupControl.ResumeLayout(false);
            this.groupControl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spnHaftalikSaat.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueOgretmen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDersKodu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDersAdi.Properties)).EndInit();
            this.ResumeLayout(false);
        }
        #endregion

        private DevExpress.XtraEditors.PanelControl pnlHeader;
        private DevExpress.XtraEditors.LabelControl lblBaslik;
        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraEditors.GroupControl groupControl;
        private DevExpress.XtraEditors.LabelControl lbl1;
        private DevExpress.XtraEditors.LabelControl lbl2;
        private DevExpress.XtraEditors.LabelControl lbl3;
        private DevExpress.XtraEditors.LabelControl lbl4;
        private DevExpress.XtraEditors.TextEdit txtDersAdi;
        private DevExpress.XtraEditors.TextEdit txtDersKodu;
        private DevExpress.XtraEditors.LookUpEdit lueOgretmen;
        private DevExpress.XtraEditors.SpinEdit spnHaftalikSaat;
        private DevExpress.XtraEditors.SimpleButton btnYeni;
        private DevExpress.XtraEditors.SimpleButton btnKaydet;
        private DevExpress.XtraEditors.SimpleButton btnSil;
    }
}
