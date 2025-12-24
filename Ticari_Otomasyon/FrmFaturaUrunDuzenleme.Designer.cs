namespace Ticari_Otomasyon
{
    partial class FrmFaturaUrunDuzenleme
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmFaturaUrunDuzenleme));
            this.groupControl5 = new DevExpress.XtraEditors.GroupControl();
            this.BtnGuncelle = new DevExpress.XtraEditors.SimpleButton();
            this.BtnSil = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.TxtTutar = new DevExpress.XtraEditors.TextEdit();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.TxtFiyat = new DevExpress.XtraEditors.TextEdit();
            this.labelControl11 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            this.TxtMiktar = new DevExpress.XtraEditors.TextEdit();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.TxtUrunId = new DevExpress.XtraEditors.TextEdit();
            this.TxtUrunAd = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl5)).BeginInit();
            this.groupControl5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TxtTutar.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtFiyat.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtMiktar.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtUrunId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtUrunAd.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl5
            // 
            this.groupControl5.Controls.Add(this.BtnGuncelle);
            this.groupControl5.Controls.Add(this.BtnSil);
            this.groupControl5.Controls.Add(this.labelControl6);
            this.groupControl5.Controls.Add(this.TxtTutar);
            this.groupControl5.Controls.Add(this.labelControl9);
            this.groupControl5.Controls.Add(this.TxtFiyat);
            this.groupControl5.Controls.Add(this.labelControl11);
            this.groupControl5.Controls.Add(this.labelControl10);
            this.groupControl5.Controls.Add(this.TxtMiktar);
            this.groupControl5.Controls.Add(this.labelControl8);
            this.groupControl5.Controls.Add(this.TxtUrunId);
            this.groupControl5.Controls.Add(this.TxtUrunAd);
            this.groupControl5.Location = new System.Drawing.Point(8, 2);
            this.groupControl5.Margin = new System.Windows.Forms.Padding(30, 30, 30, 30);
            this.groupControl5.Name = "groupControl5";
            this.groupControl5.ShowCaption = false;
            this.groupControl5.Size = new System.Drawing.Size(474, 440);
            this.groupControl5.TabIndex = 1;
            this.groupControl5.Text = "groupControl5";
            // 
            // BtnGuncelle
            // 
            this.BtnGuncelle.Appearance.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnGuncelle.Appearance.Options.UseFont = true;
            this.BtnGuncelle.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BtnGuncelle.ImageOptions.Image")));
            this.BtnGuncelle.Location = new System.Drawing.Point(181, 279);
            this.BtnGuncelle.Margin = new System.Windows.Forms.Padding(38, 38, 38, 38);
            this.BtnGuncelle.Name = "BtnGuncelle";
            this.BtnGuncelle.Size = new System.Drawing.Size(241, 56);
            this.BtnGuncelle.TabIndex = 45;
            this.BtnGuncelle.Text = "GÜNCELLE";
            this.BtnGuncelle.Click += new System.EventHandler(this.BtnGuncelle_Click);
            // 
            // BtnSil
            // 
            this.BtnSil.Appearance.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnSil.Appearance.Options.UseFont = true;
            this.BtnSil.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BtnSil.ImageOptions.Image")));
            this.BtnSil.Location = new System.Drawing.Point(181, 352);
            this.BtnSil.Margin = new System.Windows.Forms.Padding(38, 38, 38, 38);
            this.BtnSil.Name = "BtnSil";
            this.BtnSil.Size = new System.Drawing.Size(242, 51);
            this.BtnSil.TabIndex = 44;
            this.BtnSil.Text = "SİL\r\n";
            this.BtnSil.Click += new System.EventHandler(this.BtnSil_Click);
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl6.Appearance.Options.UseFont = true;
            this.labelControl6.Location = new System.Drawing.Point(83, 224);
            this.labelControl6.Margin = new System.Windows.Forms.Padding(30, 30, 30, 30);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(62, 22);
            this.labelControl6.TabIndex = 37;
            this.labelControl6.Text = "TUTAR:";
            // 
            // TxtTutar
            // 
            this.TxtTutar.Location = new System.Drawing.Point(180, 218);
            this.TxtTutar.Margin = new System.Windows.Forms.Padding(30, 30, 30, 30);
            this.TxtTutar.Name = "TxtTutar";
            this.TxtTutar.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TxtTutar.Properties.Appearance.Options.UseFont = true;
            this.TxtTutar.Size = new System.Drawing.Size(241, 28);
            this.TxtTutar.TabIndex = 41;
            // 
            // labelControl9
            // 
            this.labelControl9.Appearance.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl9.Appearance.Options.UseFont = true;
            this.labelControl9.Location = new System.Drawing.Point(91, 170);
            this.labelControl9.Margin = new System.Windows.Forms.Padding(30, 30, 30, 30);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(54, 22);
            this.labelControl9.TabIndex = 33;
            this.labelControl9.Text = "FİYAT:";
            // 
            // TxtFiyat
            // 
            this.TxtFiyat.Location = new System.Drawing.Point(180, 170);
            this.TxtFiyat.Margin = new System.Windows.Forms.Padding(30, 30, 30, 30);
            this.TxtFiyat.Name = "TxtFiyat";
            this.TxtFiyat.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TxtFiyat.Properties.Appearance.Options.UseFont = true;
            this.TxtFiyat.Size = new System.Drawing.Size(241, 28);
            this.TxtFiyat.TabIndex = 40;
            // 
            // labelControl11
            // 
            this.labelControl11.Appearance.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl11.Appearance.Options.UseFont = true;
            this.labelControl11.Location = new System.Drawing.Point(70, 126);
            this.labelControl11.Margin = new System.Windows.Forms.Padding(30, 30, 30, 30);
            this.labelControl11.Name = "labelControl11";
            this.labelControl11.Size = new System.Drawing.Size(71, 22);
            this.labelControl11.TabIndex = 32;
            this.labelControl11.Text = "MİKTAR:";
            // 
            // labelControl10
            // 
            this.labelControl10.Appearance.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl10.Appearance.Options.UseFont = true;
            this.labelControl10.Location = new System.Drawing.Point(56, 82);
            this.labelControl10.Margin = new System.Windows.Forms.Padding(30, 30, 30, 30);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(82, 22);
            this.labelControl10.TabIndex = 28;
            this.labelControl10.Text = "ÜRÜN AD:";
            // 
            // TxtMiktar
            // 
            this.TxtMiktar.Location = new System.Drawing.Point(180, 121);
            this.TxtMiktar.Margin = new System.Windows.Forms.Padding(30, 30, 30, 30);
            this.TxtMiktar.Name = "TxtMiktar";
            this.TxtMiktar.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TxtMiktar.Properties.Appearance.Options.UseFont = true;
            this.TxtMiktar.Size = new System.Drawing.Size(241, 28);
            this.TxtMiktar.TabIndex = 39;
            // 
            // labelControl8
            // 
            this.labelControl8.Appearance.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl8.Appearance.Options.UseFont = true;
            this.labelControl8.Location = new System.Drawing.Point(61, 32);
            this.labelControl8.Margin = new System.Windows.Forms.Padding(30, 30, 30, 30);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(78, 22);
            this.labelControl8.TabIndex = 27;
            this.labelControl8.Text = "ÜRÜN ID:";
            // 
            // TxtUrunId
            // 
            this.TxtUrunId.Location = new System.Drawing.Point(181, 26);
            this.TxtUrunId.Margin = new System.Windows.Forms.Padding(30, 30, 30, 30);
            this.TxtUrunId.Name = "TxtUrunId";
            this.TxtUrunId.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TxtUrunId.Properties.Appearance.Options.UseFont = true;
            this.TxtUrunId.Size = new System.Drawing.Size(241, 28);
            this.TxtUrunId.TabIndex = 36;
            // 
            // TxtUrunAd
            // 
            this.TxtUrunAd.Location = new System.Drawing.Point(181, 75);
            this.TxtUrunAd.Margin = new System.Windows.Forms.Padding(30, 30, 30, 30);
            this.TxtUrunAd.Name = "TxtUrunAd";
            this.TxtUrunAd.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TxtUrunAd.Properties.Appearance.Options.UseFont = true;
            this.TxtUrunAd.Size = new System.Drawing.Size(241, 28);
            this.TxtUrunAd.TabIndex = 38;
            // 
            // FrmFaturaUrunDuzenleme
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(488, 448);
            this.Controls.Add(this.groupControl5);
            this.Name = "FrmFaturaUrunDuzenleme";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FATURA ÜRÜN DÜZENLEME";
            this.Load += new System.EventHandler(this.FrmFaturaUrunDuzenleme_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl5)).EndInit();
            this.groupControl5.ResumeLayout(false);
            this.groupControl5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TxtTutar.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtFiyat.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtMiktar.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtUrunId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtUrunAd.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl5;
        private DevExpress.XtraEditors.SimpleButton BtnGuncelle;
        private DevExpress.XtraEditors.SimpleButton BtnSil;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.TextEdit TxtTutar;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.TextEdit TxtFiyat;
        private DevExpress.XtraEditors.LabelControl labelControl11;
        private DevExpress.XtraEditors.LabelControl labelControl10;
        private DevExpress.XtraEditors.TextEdit TxtMiktar;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.TextEdit TxtUrunId;
        private DevExpress.XtraEditors.TextEdit TxtUrunAd;
    }
}