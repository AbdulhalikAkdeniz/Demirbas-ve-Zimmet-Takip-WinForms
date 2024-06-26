namespace veriokumaexcel
{
    partial class frm_kayitlimarkamodeller
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
            this.lb_markalar = new System.Windows.Forms.ListBox();
            this.lb_modeller = new System.Windows.Forms.ListBox();
            this.txtMarka = new System.Windows.Forms.TextBox();
            this.btnMarkaEkle = new System.Windows.Forms.Button();
            this.btnModelEkle = new System.Windows.Forms.Button();
            this.txtModel = new System.Windows.Forms.TextBox();
            this.btn_markasil = new System.Windows.Forms.Button();
            this.btn_modelSil = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_turSil = new System.Windows.Forms.Button();
            this.btn_turEkle = new System.Windows.Forms.Button();
            this.txtTur = new System.Windows.Forms.TextBox();
            this.lb_turler = new System.Windows.Forms.ListBox();
            this.panel_markaKisim = new System.Windows.Forms.Panel();
            this.panel_modelKisim = new System.Windows.Forms.Panel();
            this.panel_markaKisim.SuspendLayout();
            this.panel_modelKisim.SuspendLayout();
            this.SuspendLayout();
            // 
            // lb_markalar
            // 
            this.lb_markalar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lb_markalar.FormattingEnabled = true;
            this.lb_markalar.ItemHeight = 22;
            this.lb_markalar.Location = new System.Drawing.Point(5, 49);
            this.lb_markalar.Name = "lb_markalar";
            this.lb_markalar.Size = new System.Drawing.Size(378, 268);
            this.lb_markalar.TabIndex = 0;
            this.lb_markalar.SelectedIndexChanged += new System.EventHandler(this.lb_markalar_SelectedIndexChanged);
            // 
            // lb_modeller
            // 
            this.lb_modeller.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lb_modeller.FormattingEnabled = true;
            this.lb_modeller.ItemHeight = 22;
            this.lb_modeller.Location = new System.Drawing.Point(8, 49);
            this.lb_modeller.Name = "lb_modeller";
            this.lb_modeller.Size = new System.Drawing.Size(378, 268);
            this.lb_modeller.TabIndex = 1;
            this.lb_modeller.SelectedIndexChanged += new System.EventHandler(this.lb_modeller_SelectedIndexChanged);
            // 
            // txtMarka
            // 
            this.txtMarka.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtMarka.Location = new System.Drawing.Point(5, 15);
            this.txtMarka.Name = "txtMarka";
            this.txtMarka.Size = new System.Drawing.Size(266, 28);
            this.txtMarka.TabIndex = 2;
            // 
            // btnMarkaEkle
            // 
            this.btnMarkaEkle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnMarkaEkle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMarkaEkle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnMarkaEkle.Location = new System.Drawing.Point(277, 15);
            this.btnMarkaEkle.Name = "btnMarkaEkle";
            this.btnMarkaEkle.Size = new System.Drawing.Size(103, 31);
            this.btnMarkaEkle.TabIndex = 3;
            this.btnMarkaEkle.Text = "Ekle";
            this.btnMarkaEkle.UseVisualStyleBackColor = false;
            this.btnMarkaEkle.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnModelEkle
            // 
            this.btnModelEkle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnModelEkle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModelEkle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnModelEkle.Location = new System.Drawing.Point(279, 15);
            this.btnModelEkle.Name = "btnModelEkle";
            this.btnModelEkle.Size = new System.Drawing.Size(103, 31);
            this.btnModelEkle.TabIndex = 5;
            this.btnModelEkle.Text = "Ekle";
            this.btnModelEkle.UseVisualStyleBackColor = false;
            this.btnModelEkle.Click += new System.EventHandler(this.btnModelEkle_Click);
            // 
            // txtModel
            // 
            this.txtModel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtModel.Location = new System.Drawing.Point(8, 15);
            this.txtModel.Name = "txtModel";
            this.txtModel.Size = new System.Drawing.Size(265, 28);
            this.txtModel.TabIndex = 4;
            // 
            // btn_markasil
            // 
            this.btn_markasil.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btn_markasil.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_markasil.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_markasil.Location = new System.Drawing.Point(265, 267);
            this.btn_markasil.Name = "btn_markasil";
            this.btn_markasil.Size = new System.Drawing.Size(110, 34);
            this.btn_markasil.TabIndex = 6;
            this.btn_markasil.Text = "sil";
            this.btn_markasil.UseVisualStyleBackColor = false;
            this.btn_markasil.Click += new System.EventHandler(this.button3_Click);
            // 
            // btn_modelSil
            // 
            this.btn_modelSil.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btn_modelSil.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_modelSil.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_modelSil.Location = new System.Drawing.Point(261, 267);
            this.btn_modelSil.Name = "btn_modelSil";
            this.btn_modelSil.Size = new System.Drawing.Size(110, 34);
            this.btn_modelSil.TabIndex = 7;
            this.btn_modelSil.Text = "sil";
            this.btn_modelSil.UseVisualStyleBackColor = false;
            this.btn_modelSil.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button5.Location = new System.Drawing.Point(12, 27);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(129, 53);
            this.button5.TabIndex = 8;
            this.button5.Text = "KAYDET";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(147, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(416, 16);
            this.label1.TabIndex = 11;
            this.label1.Text = "Yaptığınız değişiklikleri kaydetmek için \'KAYDET\' butonunu kullanınız.";
            // 
            // btn_turSil
            // 
            this.btn_turSil.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btn_turSil.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_turSil.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_turSil.Location = new System.Drawing.Point(272, 347);
            this.btn_turSil.Name = "btn_turSil";
            this.btn_turSil.Size = new System.Drawing.Size(110, 34);
            this.btn_turSil.TabIndex = 15;
            this.btn_turSil.Text = "sil";
            this.btn_turSil.UseVisualStyleBackColor = false;
            this.btn_turSil.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // btn_turEkle
            // 
            this.btn_turEkle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btn_turEkle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_turEkle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_turEkle.Location = new System.Drawing.Point(284, 95);
            this.btn_turEkle.Name = "btn_turEkle";
            this.btn_turEkle.Size = new System.Drawing.Size(103, 31);
            this.btn_turEkle.TabIndex = 14;
            this.btn_turEkle.Text = "Ekle";
            this.btn_turEkle.UseVisualStyleBackColor = false;
            this.btn_turEkle.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtTur
            // 
            this.txtTur.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtTur.Location = new System.Drawing.Point(12, 95);
            this.txtTur.Name = "txtTur";
            this.txtTur.Size = new System.Drawing.Size(266, 28);
            this.txtTur.TabIndex = 13;
            // 
            // lb_turler
            // 
            this.lb_turler.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lb_turler.FormattingEnabled = true;
            this.lb_turler.ItemHeight = 22;
            this.lb_turler.Location = new System.Drawing.Point(12, 129);
            this.lb_turler.Name = "lb_turler";
            this.lb_turler.Size = new System.Drawing.Size(378, 268);
            this.lb_turler.TabIndex = 12;
            this.lb_turler.SelectedIndexChanged += new System.EventHandler(this.lb_turler_SelectedIndexChanged);
            // 
            // panel_markaKisim
            // 
            this.panel_markaKisim.Controls.Add(this.btn_markasil);
            this.panel_markaKisim.Controls.Add(this.btnMarkaEkle);
            this.panel_markaKisim.Controls.Add(this.txtMarka);
            this.panel_markaKisim.Controls.Add(this.lb_markalar);
            this.panel_markaKisim.Location = new System.Drawing.Point(394, 80);
            this.panel_markaKisim.Name = "panel_markaKisim";
            this.panel_markaKisim.Size = new System.Drawing.Size(388, 327);
            this.panel_markaKisim.TabIndex = 16;
            // 
            // panel_modelKisim
            // 
            this.panel_modelKisim.Controls.Add(this.btn_modelSil);
            this.panel_modelKisim.Controls.Add(this.btnModelEkle);
            this.panel_modelKisim.Controls.Add(this.lb_modeller);
            this.panel_modelKisim.Controls.Add(this.txtModel);
            this.panel_modelKisim.Location = new System.Drawing.Point(779, 80);
            this.panel_modelKisim.Name = "panel_modelKisim";
            this.panel_modelKisim.Size = new System.Drawing.Size(391, 326);
            this.panel_modelKisim.TabIndex = 17;
            // 
            // frm_kayitlimarkamodeller
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1184, 409);
            this.Controls.Add(this.panel_markaKisim);
            this.Controls.Add(this.btn_turSil);
            this.Controls.Add(this.btn_turEkle);
            this.Controls.Add(this.txtTur);
            this.Controls.Add(this.lb_turler);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.panel_modelKisim);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "frm_kayitlimarkamodeller";
            this.Text = "Kayıtlı Marka Modeller";
            this.Load += new System.EventHandler(this.frm_kayitlimarkamodeller_Load);
            this.panel_markaKisim.ResumeLayout(false);
            this.panel_markaKisim.PerformLayout();
            this.panel_modelKisim.ResumeLayout(false);
            this.panel_modelKisim.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lb_markalar;
        private System.Windows.Forms.ListBox lb_modeller;
        private System.Windows.Forms.TextBox txtMarka;
        private System.Windows.Forms.Button btnMarkaEkle;
        private System.Windows.Forms.Button btnModelEkle;
        private System.Windows.Forms.TextBox txtModel;
        private System.Windows.Forms.Button btn_markasil;
        private System.Windows.Forms.Button btn_modelSil;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_turSil;
        private System.Windows.Forms.Button btn_turEkle;
        private System.Windows.Forms.TextBox txtTur;
        private System.Windows.Forms.ListBox lb_turler;
        private System.Windows.Forms.Panel panel_markaKisim;
        private System.Windows.Forms.Panel panel_modelKisim;
    }
}