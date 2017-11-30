namespace BuildEverything.FormFiles
{
    partial class TempConnect
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
            this.btn_Save = new System.Windows.Forms.Button();
            this.txt_PWD = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_Uid = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_Port = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_Server = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_DBName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbx_DBType = new System.Windows.Forms.ComboBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // btn_Save
            // 
            this.btn_Save.Location = new System.Drawing.Point(260, 207);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(106, 40);
            this.btn_Save.TabIndex = 25;
            this.btn_Save.Text = "保存";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // txt_PWD
            // 
            this.txt_PWD.Location = new System.Drawing.Point(372, 138);
            this.txt_PWD.Name = "txt_PWD";
            this.txt_PWD.Size = new System.Drawing.Size(154, 21);
            this.txt_PWD.TabIndex = 24;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(325, 141);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 23;
            this.label6.Text = "密码：";
            // 
            // txt_Uid
            // 
            this.txt_Uid.Location = new System.Drawing.Point(122, 138);
            this.txt_Uid.Name = "txt_Uid";
            this.txt_Uid.Size = new System.Drawing.Size(143, 21);
            this.txt_Uid.TabIndex = 22;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(65, 147);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 21;
            this.label5.Text = "用户名：";
            // 
            // txt_Port
            // 
            this.txt_Port.Location = new System.Drawing.Point(372, 91);
            this.txt_Port.Name = "txt_Port";
            this.txt_Port.Size = new System.Drawing.Size(154, 21);
            this.txt_Port.TabIndex = 20;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(325, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 19;
            this.label4.Text = "端口：";
            // 
            // txt_Server
            // 
            this.txt_Server.Location = new System.Drawing.Point(122, 97);
            this.txt_Server.Name = "txt_Server";
            this.txt_Server.Size = new System.Drawing.Size(143, 21);
            this.txt_Server.TabIndex = 18;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(63, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 17;
            this.label3.Text = "服务器：";
            // 
            // txt_DBName
            // 
            this.txt_DBName.Location = new System.Drawing.Point(372, 52);
            this.txt_DBName.Name = "txt_DBName";
            this.txt_DBName.Size = new System.Drawing.Size(154, 21);
            this.txt_DBName.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(325, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 15;
            this.label2.Text = "库名：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 14;
            this.label1.Text = "数据库类型：";
            // 
            // cbx_DBType
            // 
            this.cbx_DBType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_DBType.FormattingEnabled = true;
            this.cbx_DBType.Items.AddRange(new object[] {
            "SqlServer",
            "MySQL"});
            this.cbx_DBType.Location = new System.Drawing.Point(122, 53);
            this.cbx_DBType.Name = "cbx_DBType";
            this.cbx_DBType.Size = new System.Drawing.Size(143, 20);
            this.cbx_DBType.TabIndex = 13;
            // 
            // TempConnect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(595, 296);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.txt_PWD);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txt_Uid);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txt_Port);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_Server);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_DBName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbx_DBType);
            this.Name = "TempConnect";
            this.Text = "TempConnect";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.TextBox txt_PWD;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_Uid;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_Port;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_Server;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_DBName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbx_DBType;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}