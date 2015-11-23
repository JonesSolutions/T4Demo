namespace T4Demo
{
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Server = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Database = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Username = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Password = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.Schema = new System.Windows.Forms.TextBox();
            this.Table = new System.Windows.Forms.TextBox();
            this.UseIntegratedAuthentication = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(22, 216);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(105, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Make me proud";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Server";
            // 
            // Server
            // 
            this.Server.Location = new System.Drawing.Point(85, 12);
            this.Server.Name = "Server";
            this.Server.Size = new System.Drawing.Size(198, 20);
            this.Server.TabIndex = 1;
            this.Server.Text = "OGEDEISPC\\SQLEXPRESS";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Database";
            // 
            // Database
            // 
            this.Database.Location = new System.Drawing.Point(85, 36);
            this.Database.Name = "Database";
            this.Database.Size = new System.Drawing.Size(198, 20);
            this.Database.TabIndex = 2;
            this.Database.Text = "AdventureWorksDW";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "UserName";
            // 
            // Username
            // 
            this.Username.Location = new System.Drawing.Point(85, 80);
            this.Username.Name = "Username";
            this.Username.Size = new System.Drawing.Size(198, 20);
            this.Username.TabIndex = 4;
            this.Username.Text = "Demo";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Password";
            // 
            // Password
            // 
            this.Password.Location = new System.Drawing.Point(85, 104);
            this.Password.Name = "Password";
            this.Password.PasswordChar = '*';
            this.Password.Size = new System.Drawing.Size(198, 20);
            this.Password.TabIndex = 5;
            this.Password.Text = "P@ssword";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 159);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Table";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(19, 136);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Schema";
            // 
            // Schema
            // 
            this.Schema.Location = new System.Drawing.Point(85, 133);
            this.Schema.Name = "Schema";
            this.Schema.Size = new System.Drawing.Size(198, 20);
            this.Schema.TabIndex = 6;
            this.Schema.Text = "dbo";
            // 
            // Table
            // 
            this.Table.Location = new System.Drawing.Point(85, 156);
            this.Table.Name = "Table";
            this.Table.Size = new System.Drawing.Size(198, 20);
            this.Table.TabIndex = 7;
            this.Table.Text = "DimAccount";
            // 
            // UseIntegratedAuthentication
            // 
            this.UseIntegratedAuthentication.AutoSize = true;
            this.UseIntegratedAuthentication.Location = new System.Drawing.Point(22, 62);
            this.UseIntegratedAuthentication.Name = "UseIntegratedAuthentication";
            this.UseIntegratedAuthentication.Size = new System.Drawing.Size(167, 17);
            this.UseIntegratedAuthentication.TabIndex = 3;
            this.UseIntegratedAuthentication.Text = "Use Integrated Authentication";
            this.UseIntegratedAuthentication.UseVisualStyleBackColor = true;
            this.UseIntegratedAuthentication.CheckedChanged += new System.EventHandler(this.UseIntegratedAuthentication_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.UseIntegratedAuthentication);
            this.Controls.Add(this.Table);
            this.Controls.Add(this.Schema);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Password);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Username);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Database);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Server);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Server;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Database;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Username;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox Password;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox Schema;
        private System.Windows.Forms.TextBox Table;
        private System.Windows.Forms.CheckBox UseIntegratedAuthentication;
    }
}

