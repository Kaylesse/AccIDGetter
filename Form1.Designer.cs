namespace WoloSummonerIDApp
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.API_Key = new System.Windows.Forms.TextBox();
            this.btnAPI = new System.Windows.Forms.Button();
            this.lblVerify = new System.Windows.Forms.Label();
            this.cbMultinick = new System.Windows.Forms.CheckBox();
            this.txtNicks = new System.Windows.Forms.TextBox();
            this.btnRun = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblNick = new System.Windows.Forms.Label();
            this.cbpassword = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // API_Key
            // 
            this.API_Key.Location = new System.Drawing.Point(63, 13);
            this.API_Key.Name = "API_Key";
            this.API_Key.Size = new System.Drawing.Size(231, 20);
            this.API_Key.TabIndex = 0;
            this.API_Key.TextChanged += new System.EventHandler(this.API_Key_TextChanged);
            // 
            // btnAPI
            // 
            this.btnAPI.Location = new System.Drawing.Point(300, 12);
            this.btnAPI.Name = "btnAPI";
            this.btnAPI.Size = new System.Drawing.Size(75, 23);
            this.btnAPI.TabIndex = 1;
            this.btnAPI.Text = "Check";
            this.btnAPI.UseVisualStyleBackColor = true;
            this.btnAPI.Click += new System.EventHandler(this.btnAPI_Click);
            // 
            // lblVerify
            // 
            this.lblVerify.AutoSize = true;
            this.lblVerify.Location = new System.Drawing.Point(381, 17);
            this.lblVerify.Name = "lblVerify";
            this.lblVerify.Size = new System.Drawing.Size(27, 13);
            this.lblVerify.TabIndex = 2;
            this.lblVerify.Text = "N/A";
            // 
            // cbMultinick
            // 
            this.cbMultinick.AutoSize = true;
            this.cbMultinick.Location = new System.Drawing.Point(13, 40);
            this.cbMultinick.Name = "cbMultinick";
            this.cbMultinick.Size = new System.Drawing.Size(104, 17);
            this.cbMultinick.TabIndex = 3;
            this.cbMultinick.Text = "More nicknames";
            this.cbMultinick.UseVisualStyleBackColor = true;
            this.cbMultinick.CheckedChanged += new System.EventHandler(this.cbMultinick_CheckedChanged);
            // 
            // txtNicks
            // 
            this.txtNicks.Location = new System.Drawing.Point(13, 64);
            this.txtNicks.Name = "txtNicks";
            this.txtNicks.Size = new System.Drawing.Size(250, 20);
            this.txtNicks.TabIndex = 4;
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(300, 40);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(75, 23);
            this.btnRun.TabIndex = 5;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "API Key";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(382, 40);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblNick
            // 
            this.lblNick.AutoSize = true;
            this.lblNick.Location = new System.Drawing.Point(297, 71);
            this.lblNick.Name = "lblNick";
            this.lblNick.Size = new System.Drawing.Size(27, 13);
            this.lblNick.TabIndex = 8;
            this.lblNick.Text = "N/A";
            // 
            // cbpassword
            // 
            this.cbpassword.AutoSize = true;
            this.cbpassword.Location = new System.Drawing.Point(180, 40);
            this.cbpassword.Name = "cbpassword";
            this.cbpassword.Size = new System.Drawing.Size(94, 17);
            this.cbpassword.TabIndex = 9;
            this.cbpassword.Text = "Show API Key";
            this.cbpassword.UseVisualStyleBackColor = true;
            this.cbpassword.CheckedChanged += new System.EventHandler(this.cbpassword_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 96);
            this.Controls.Add(this.cbpassword);
            this.Controls.Add(this.lblNick);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.txtNicks);
            this.Controls.Add(this.cbMultinick);
            this.Controls.Add(this.lblVerify);
            this.Controls.Add(this.btnAPI);
            this.Controls.Add(this.API_Key);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "AccountID Getter";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox API_Key;
        private System.Windows.Forms.Button btnAPI;
        private System.Windows.Forms.Label lblVerify;
        private System.Windows.Forms.CheckBox cbMultinick;
        private System.Windows.Forms.TextBox txtNicks;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblNick;
        private System.Windows.Forms.CheckBox cbpassword;
    }
}

