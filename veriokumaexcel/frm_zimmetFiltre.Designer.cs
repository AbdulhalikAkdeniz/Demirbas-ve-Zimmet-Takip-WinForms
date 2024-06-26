namespace veriokumaexcel
{
    partial class frm_zimmetFiltre
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
            this.chkBirim = new System.Windows.Forms.CheckBox();
            this.chkAdsoyad = new System.Windows.Forms.CheckBox();
            this.chkUnvan = new System.Windows.Forms.CheckBox();
            this.chkSicil = new System.Windows.Forms.CheckBox();
            this.chkMM = new System.Windows.Forms.CheckBox();
            this.txtBirim = new System.Windows.Forms.TextBox();
            this.chkSerino = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.txtAdsoyad = new System.Windows.Forms.TextBox();
            this.txtUnvan = new System.Windows.Forms.TextBox();
            this.txtSicil = new System.Windows.Forms.TextBox();
            this.txtMM = new System.Windows.Forms.TextBox();
            this.txtSerino = new System.Windows.Forms.TextBox();
            this.txtDemNo = new System.Windows.Forms.TextBox();
            this.chk_demno = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // chkBirim
            // 
            this.chkBirim.AutoSize = true;
            this.chkBirim.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.chkBirim.Location = new System.Drawing.Point(46, 78);
            this.chkBirim.Name = "chkBirim";
            this.chkBirim.Size = new System.Drawing.Size(70, 26);
            this.chkBirim.TabIndex = 0;
            this.chkBirim.Text = "birim";
            this.chkBirim.UseVisualStyleBackColor = true;
            this.chkBirim.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // chkAdsoyad
            // 
            this.chkAdsoyad.AutoSize = true;
            this.chkAdsoyad.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.chkAdsoyad.Location = new System.Drawing.Point(46, 119);
            this.chkAdsoyad.Name = "chkAdsoyad";
            this.chkAdsoyad.Size = new System.Drawing.Size(100, 26);
            this.chkAdsoyad.TabIndex = 1;
            this.chkAdsoyad.Text = "adsoyad";
            this.chkAdsoyad.UseVisualStyleBackColor = true;
            this.chkAdsoyad.CheckedChanged += new System.EventHandler(this.chkAd_CheckedChanged);
            // 
            // chkUnvan
            // 
            this.chkUnvan.AutoSize = true;
            this.chkUnvan.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.chkUnvan.Location = new System.Drawing.Point(46, 163);
            this.chkUnvan.Name = "chkUnvan";
            this.chkUnvan.Size = new System.Drawing.Size(81, 26);
            this.chkUnvan.TabIndex = 3;
            this.chkUnvan.Text = "unvan";
            this.chkUnvan.UseVisualStyleBackColor = true;
            this.chkUnvan.CheckedChanged += new System.EventHandler(this.chkUnvan_CheckedChanged);
            // 
            // chkSicil
            // 
            this.chkSicil.AutoSize = true;
            this.chkSicil.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.chkSicil.Location = new System.Drawing.Point(46, 207);
            this.chkSicil.Name = "chkSicil";
            this.chkSicil.Size = new System.Drawing.Size(62, 26);
            this.chkSicil.TabIndex = 4;
            this.chkSicil.Text = "sicil";
            this.chkSicil.UseVisualStyleBackColor = true;
            this.chkSicil.CheckedChanged += new System.EventHandler(this.chkSicil_CheckedChanged);
            // 
            // chkMM
            // 
            this.chkMM.AutoSize = true;
            this.chkMM.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.chkMM.Location = new System.Drawing.Point(46, 252);
            this.chkMM.Name = "chkMM";
            this.chkMM.Size = new System.Drawing.Size(134, 26);
            this.chkMM.TabIndex = 5;
            this.chkMM.Text = "marka model";
            this.chkMM.UseVisualStyleBackColor = true;
            this.chkMM.CheckedChanged += new System.EventHandler(this.chkMM_CheckedChanged);
            // 
            // txtBirim
            // 
            this.txtBirim.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtBirim.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtBirim.Location = new System.Drawing.Point(221, 79);
            this.txtBirim.Name = "txtBirim";
            this.txtBirim.Size = new System.Drawing.Size(255, 28);
            this.txtBirim.TabIndex = 6;
            this.txtBirim.Visible = false;
            // 
            // chkSerino
            // 
            this.chkSerino.AutoSize = true;
            this.chkSerino.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.chkSerino.Location = new System.Drawing.Point(46, 295);
            this.chkSerino.Name = "chkSerino";
            this.chkSerino.Size = new System.Drawing.Size(81, 26);
            this.chkSerino.TabIndex = 7;
            this.chkSerino.Text = "serino";
            this.chkSerino.UseVisualStyleBackColor = true;
            this.chkSerino.CheckedChanged += new System.EventHandler(this.chkSerino_CheckedChanged);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button1.Location = new System.Drawing.Point(260, 387);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(216, 49);
            this.button1.TabIndex = 9;
            this.button1.Text = "Uygula";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtAdsoyad
            // 
            this.txtAdsoyad.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtAdsoyad.Location = new System.Drawing.Point(221, 120);
            this.txtAdsoyad.Name = "txtAdsoyad";
            this.txtAdsoyad.Size = new System.Drawing.Size(255, 28);
            this.txtAdsoyad.TabIndex = 10;
            this.txtAdsoyad.Visible = false;
            // 
            // txtUnvan
            // 
            this.txtUnvan.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtUnvan.Location = new System.Drawing.Point(221, 164);
            this.txtUnvan.Name = "txtUnvan";
            this.txtUnvan.Size = new System.Drawing.Size(255, 28);
            this.txtUnvan.TabIndex = 12;
            this.txtUnvan.Visible = false;
            // 
            // txtSicil
            // 
            this.txtSicil.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtSicil.Location = new System.Drawing.Point(221, 208);
            this.txtSicil.Name = "txtSicil";
            this.txtSicil.Size = new System.Drawing.Size(255, 28);
            this.txtSicil.TabIndex = 13;
            this.txtSicil.Visible = false;
            // 
            // txtMM
            // 
            this.txtMM.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtMM.Location = new System.Drawing.Point(221, 251);
            this.txtMM.Name = "txtMM";
            this.txtMM.Size = new System.Drawing.Size(255, 28);
            this.txtMM.TabIndex = 14;
            this.txtMM.Visible = false;
            this.txtMM.TextChanged += new System.EventHandler(this.txtMM_TextChanged);
            // 
            // txtSerino
            // 
            this.txtSerino.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtSerino.Location = new System.Drawing.Point(221, 294);
            this.txtSerino.Name = "txtSerino";
            this.txtSerino.Size = new System.Drawing.Size(255, 28);
            this.txtSerino.TabIndex = 15;
            this.txtSerino.Visible = false;
            // 
            // txtDemNo
            // 
            this.txtDemNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtDemNo.Location = new System.Drawing.Point(221, 336);
            this.txtDemNo.Name = "txtDemNo";
            this.txtDemNo.Size = new System.Drawing.Size(255, 28);
            this.txtDemNo.TabIndex = 17;
            this.txtDemNo.Visible = false;
            // 
            // chk_demno
            // 
            this.chk_demno.AutoSize = true;
            this.chk_demno.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.chk_demno.Location = new System.Drawing.Point(46, 337);
            this.chk_demno.Name = "chk_demno";
            this.chk_demno.Size = new System.Drawing.Size(96, 26);
            this.chk_demno.TabIndex = 16;
            this.chk_demno.Text = "dem_no";
            this.chk_demno.UseVisualStyleBackColor = true;
            this.chk_demno.CheckedChanged += new System.EventHandler(this.chk_demno_CheckedChanged);
            // 
            // frm_zimmetFiltre
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(534, 489);
            this.Controls.Add(this.txtDemNo);
            this.Controls.Add(this.chk_demno);
            this.Controls.Add(this.txtSerino);
            this.Controls.Add(this.txtMM);
            this.Controls.Add(this.txtSicil);
            this.Controls.Add(this.txtUnvan);
            this.Controls.Add(this.txtAdsoyad);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.chkSerino);
            this.Controls.Add(this.txtBirim);
            this.Controls.Add(this.chkMM);
            this.Controls.Add(this.chkSicil);
            this.Controls.Add(this.chkUnvan);
            this.Controls.Add(this.chkAdsoyad);
            this.Controls.Add(this.chkBirim);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "frm_zimmetFiltre";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "zimmet filtre";
            this.Load += new System.EventHandler(this.frm_zimmetFiltre_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkBirim;
        private System.Windows.Forms.CheckBox chkAdsoyad;
        private System.Windows.Forms.CheckBox chkUnvan;
        private System.Windows.Forms.CheckBox chkSicil;
        private System.Windows.Forms.CheckBox chkMM;
        private System.Windows.Forms.TextBox txtBirim;
        private System.Windows.Forms.CheckBox chkSerino;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtAdsoyad;
        private System.Windows.Forms.TextBox txtUnvan;
        private System.Windows.Forms.TextBox txtSicil;
        private System.Windows.Forms.TextBox txtMM;
        private System.Windows.Forms.TextBox txtSerino;
        private System.Windows.Forms.TextBox txtDemNo;
        private System.Windows.Forms.CheckBox chk_demno;
    }
}