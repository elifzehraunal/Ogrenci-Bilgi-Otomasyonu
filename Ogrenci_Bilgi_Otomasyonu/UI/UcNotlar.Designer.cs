namespace Ogrenci_Bilgi_Otomasyonu.UI
{
    partial class UcNotlar
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
            this.spnSozlu2 = new DevExpress.XtraEditors.SpinEdit();
            this.lbl6 = new DevExpress.XtraEditors.LabelControl();
            this.spnSozlu1 = new DevExpress.XtraEditors.SpinEdit();
            this.lbl5 = new DevExpress.XtraEditors.LabelControl();
            this.spnYazili2 = new DevExpress.XtraEditors.SpinEdit();
            this.lbl4 = new DevExpress.XtraEditors.LabelControl();
            this.spnYazili1 = new DevExpress.XtraEditors.SpinEdit();
            this.lbl3 = new DevExpress.XtraEditors.LabelControl();
            this.lueDers = new DevExpress.XtraEditors.LookUpEdit();
            this.lbl2 = new DevExpress.XtraEditors.LabelControl();
            this.lueOgrenci = new DevExpress.XtraEditors.LookUpEdit();
            this.lblOgrenci = new DevExpress.XtraEditors.LabelControl();
            this.lueSinif = new DevExpress.XtraEditors.LookUpEdit();
            this.lbl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.pnlHeader)).BeginInit();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl)).BeginInit();
            this.groupControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spnSozlu2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spnSozlu1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spnYazili2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spnYazili1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueDers.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueOgrenci.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueSinif.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.Appearance.BackColor = System.Drawing.Color.FromArgb(108, 99, 255);
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
            this.lblBaslik.Text = "📊 NOT GİRİŞİ";
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
            this.groupControl.Controls.Add(this.spnSozlu2);
            this.groupControl.Controls.Add(this.lbl6);
            this.groupControl.Controls.Add(this.spnSozlu1);
            this.groupControl.Controls.Add(this.lbl5);
            this.groupControl.Controls.Add(this.spnYazili2);
            this.groupControl.Controls.Add(this.lbl4);
            this.groupControl.Controls.Add(this.spnYazili1);
            this.groupControl.Controls.Add(this.lbl3);
            this.groupControl.Controls.Add(this.lueDers);
            this.groupControl.Controls.Add(this.lbl2);
            this.groupControl.Controls.Add(this.lueOgrenci);
            this.groupControl.Controls.Add(this.lblOgrenci);
            this.groupControl.Controls.Add(this.lueSinif);
            this.groupControl.Controls.Add(this.lbl1);
            this.groupControl.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupControl.Location = new System.Drawing.Point(550, 50);
            this.groupControl.Name = "groupControl";
            this.groupControl.Size = new System.Drawing.Size(350, 550);
            this.groupControl.TabIndex = 2;
            this.groupControl.Text = "📝 Not Bilgileri";
            // 
            // lbl1 - Sınıf
            // 
            this.lbl1.Location = new System.Drawing.Point(15, 35);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(60, 13);
            this.lbl1.TabIndex = 0;
            this.lbl1.Text = "🏫 Sınıf:";
            // 
            // lueSinif
            // 
            this.lueSinif.Location = new System.Drawing.Point(100, 32);
            this.lueSinif.Name = "lueSinif";
            this.lueSinif.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueSinif.Size = new System.Drawing.Size(230, 20);
            this.lueSinif.TabIndex = 1;
            this.lueSinif.EditValueChanged += new System.EventHandler(this.lueSinif_EditValueChanged);
            // 
            // lblOgrenci - Öğrenci
            // 
            this.lblOgrenci.Location = new System.Drawing.Point(15, 70);
            this.lblOgrenci.Name = "lblOgrenci";
            this.lblOgrenci.Size = new System.Drawing.Size(70, 13);
            this.lblOgrenci.TabIndex = 2;
            this.lblOgrenci.Text = "👨‍🎓 Öğrenci:";
            // 
            // lueOgrenci
            // 
            this.lueOgrenci.Location = new System.Drawing.Point(100, 67);
            this.lueOgrenci.Name = "lueOgrenci";
            this.lueOgrenci.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueOgrenci.Size = new System.Drawing.Size(230, 20);
            this.lueOgrenci.TabIndex = 3;
            // 
            // lbl2 - Ders
            // 
            this.lbl2.Location = new System.Drawing.Point(15, 105);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(50, 13);
            this.lbl2.TabIndex = 4;
            this.lbl2.Text = "📚 Ders:";
            // 
            // lueDers
            // 
            this.lueDers.Location = new System.Drawing.Point(100, 102);
            this.lueDers.Name = "lueDers";
            this.lueDers.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueDers.Size = new System.Drawing.Size(230, 20);
            this.lueDers.TabIndex = 5;
            // 
            // lbl3 - Yazılı 1
            // 
            this.lbl3.Location = new System.Drawing.Point(15, 145);
            this.lbl3.Name = "lbl3";
            this.lbl3.Size = new System.Drawing.Size(60, 13);
            this.lbl3.TabIndex = 6;
            this.lbl3.Text = "📝 Yazılı 1:";
            // 
            // spnYazili1
            // 
            this.spnYazili1.EditValue = new decimal(0);
            this.spnYazili1.Location = new System.Drawing.Point(100, 142);
            this.spnYazili1.Name = "spnYazili1";
            this.spnYazili1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spnYazili1.Properties.MaxValue = new decimal(100);
            this.spnYazili1.Properties.MinValue = new decimal(0);
            this.spnYazili1.Size = new System.Drawing.Size(100, 20);
            this.spnYazili1.TabIndex = 7;
            // 
            // lbl4 - Yazılı 2
            // 
            this.lbl4.Location = new System.Drawing.Point(15, 180);
            this.lbl4.Name = "lbl4";
            this.lbl4.Size = new System.Drawing.Size(60, 13);
            this.lbl4.TabIndex = 8;
            this.lbl4.Text = "📝 Yazılı 2:";
            // 
            // spnYazili2
            // 
            this.spnYazili2.EditValue = new decimal(0);
            this.spnYazili2.Location = new System.Drawing.Point(100, 177);
            this.spnYazili2.Name = "spnYazili2";
            this.spnYazili2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spnYazili2.Properties.MaxValue = new decimal(100);
            this.spnYazili2.Properties.MinValue = new decimal(0);
            this.spnYazili2.Size = new System.Drawing.Size(100, 20);
            this.spnYazili2.TabIndex = 9;
            // 
            // lbl5 - Sözlü 1
            // 
            this.lbl5.Location = new System.Drawing.Point(15, 215);
            this.lbl5.Name = "lbl5";
            this.lbl5.Size = new System.Drawing.Size(60, 13);
            this.lbl5.TabIndex = 10;
            this.lbl5.Text = "🎤 Sözlü 1:";
            // 
            // spnSozlu1
            // 
            this.spnSozlu1.EditValue = new decimal(0);
            this.spnSozlu1.Location = new System.Drawing.Point(100, 212);
            this.spnSozlu1.Name = "spnSozlu1";
            this.spnSozlu1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spnSozlu1.Properties.MaxValue = new decimal(100);
            this.spnSozlu1.Properties.MinValue = new decimal(0);
            this.spnSozlu1.Size = new System.Drawing.Size(100, 20);
            this.spnSozlu1.TabIndex = 11;
            // 
            // lbl6 - Sözlü 2
            // 
            this.lbl6.Location = new System.Drawing.Point(15, 250);
            this.lbl6.Name = "lbl6";
            this.lbl6.Size = new System.Drawing.Size(60, 13);
            this.lbl6.TabIndex = 12;
            this.lbl6.Text = "🎤 Sözlü 2:";
            // 
            // spnSozlu2
            // 
            this.spnSozlu2.EditValue = new decimal(0);
            this.spnSozlu2.Location = new System.Drawing.Point(100, 247);
            this.spnSozlu2.Name = "spnSozlu2";
            this.spnSozlu2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spnSozlu2.Properties.MaxValue = new decimal(100);
            this.spnSozlu2.Properties.MinValue = new decimal(0);
            this.spnSozlu2.Size = new System.Drawing.Size(100, 20);
            this.spnSozlu2.TabIndex = 13;
            // 
            // btnYeni
            // 
            this.btnYeni.Appearance.BackColor = System.Drawing.Color.FromArgb(52, 168, 83);
            this.btnYeni.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnYeni.Appearance.Options.UseBackColor = true;
            this.btnYeni.Appearance.Options.UseForeColor = true;
            this.btnYeni.Location = new System.Drawing.Point(15, 290);
            this.btnYeni.Name = "btnYeni";
            this.btnYeni.Size = new System.Drawing.Size(100, 35);
            this.btnYeni.TabIndex = 14;
            this.btnYeni.Text = "➕ Yeni";
            this.btnYeni.Click += new System.EventHandler(this.btnYeni_Click);
            // 
            // btnKaydet
            // 
            this.btnKaydet.Appearance.BackColor = System.Drawing.Color.FromArgb(66, 133, 244);
            this.btnKaydet.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnKaydet.Appearance.Options.UseBackColor = true;
            this.btnKaydet.Appearance.Options.UseForeColor = true;
            this.btnKaydet.Location = new System.Drawing.Point(120, 290);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(100, 35);
            this.btnKaydet.TabIndex = 15;
            this.btnKaydet.Text = "💾 Kaydet";
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // btnSil
            // 
            this.btnSil.Appearance.BackColor = System.Drawing.Color.FromArgb(234, 67, 53);
            this.btnSil.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnSil.Appearance.Options.UseBackColor = true;
            this.btnSil.Appearance.Options.UseForeColor = true;
            this.btnSil.Location = new System.Drawing.Point(225, 290);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(100, 35);
            this.btnSil.TabIndex = 16;
            this.btnSil.Text = "🗑️ Sil";
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // UcNotlar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridControl);
            this.Controls.Add(this.groupControl);
            this.Controls.Add(this.pnlHeader);
            this.Name = "UcNotlar";
            this.Size = new System.Drawing.Size(900, 600);
            ((System.ComponentModel.ISupportInitialize)(this.pnlHeader)).EndInit();
            this.pnlHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl)).EndInit();
            this.groupControl.ResumeLayout(false);
            this.groupControl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spnSozlu2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spnSozlu1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spnYazili2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spnYazili1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueDers.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueOgrenci.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueSinif.Properties)).EndInit();
            this.ResumeLayout(false);
        }
        #endregion

        private DevExpress.XtraEditors.PanelControl pnlHeader;
        private DevExpress.XtraEditors.LabelControl lblBaslik;
        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraEditors.GroupControl groupControl;
        private DevExpress.XtraEditors.LabelControl lbl1, lbl2, lbl3, lbl4, lbl5, lbl6, lblOgrenci;
        private DevExpress.XtraEditors.LookUpEdit lueSinif, lueOgrenci, lueDers;
        private DevExpress.XtraEditors.SpinEdit spnYazili1, spnYazili2, spnSozlu1, spnSozlu2;
        private DevExpress.XtraEditors.SimpleButton btnYeni, btnKaydet, btnSil;
    }
}
