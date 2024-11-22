namespace QueryValuta
{
    partial class ProxyParam
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
            this.Edt_AuthType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Edt_UserName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Edt_Password = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Edt_Domain = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Edt_AuthType
            // 
            this.Edt_AuthType.AutoCompleteCustomSource.AddRange(new string[] {
            "Basic",
            "NTLM",
            "Kerberos",
            "Digest"});
            this.Edt_AuthType.Location = new System.Drawing.Point(70, 116);
            this.Edt_AuthType.Name = "Edt_AuthType";
            this.Edt_AuthType.Size = new System.Drawing.Size(121, 21);
            this.Edt_AuthType.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 124);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Тип";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Имя";
            // 
            // Edt_UserName
            // 
            this.Edt_UserName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.Edt_UserName.Location = new System.Drawing.Point(70, 23);
            this.Edt_UserName.Name = "Edt_UserName";
            this.Edt_UserName.Size = new System.Drawing.Size(121, 20);
            this.Edt_UserName.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Пароль";
            // 
            // Edt_Password
            // 
            this.Edt_Password.Location = new System.Drawing.Point(70, 54);
            this.Edt_Password.Name = "Edt_Password";
            this.Edt_Password.PasswordChar = '*';
            this.Edt_Password.Size = new System.Drawing.Size(121, 20);
            this.Edt_Password.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Домен";
            // 
            // Edt_Domain
            // 
            this.Edt_Domain.Location = new System.Drawing.Point(70, 88);
            this.Edt_Domain.Name = "Edt_Domain";
            this.Edt_Domain.Size = new System.Drawing.Size(121, 20);
            this.Edt_Domain.TabIndex = 7;
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(87, 161);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Сохранить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ProxyParam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(229, 214);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Edt_Domain);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Edt_Password);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Edt_UserName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Edt_AuthType);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProxyParam";
            this.Text = "ProxyParam";
            this.Load += new System.EventHandler(this.ProxyParam_Load);
            this.Shown += new System.EventHandler(this.ProxyParam_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.ComboBox Edt_AuthType;
        public System.Windows.Forms.TextBox Edt_UserName;
        public System.Windows.Forms.TextBox Edt_Password;
        public System.Windows.Forms.TextBox Edt_Domain;

    }
}