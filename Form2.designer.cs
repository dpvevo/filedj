namespace DPshare
{
    partial class Player
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        // Davi
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
            this.Stop = new System.Windows.Forms.Button();
            this.Play = new System.Windows.Forms.Button();
            this.volup = new System.Windows.Forms.Button();
            this.voldown = new System.Windows.Forms.Button();
            this.volume = new System.Windows.Forms.Label();
            this.Search = new System.Windows.Forms.TextBox();
            this.Account = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.ID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Title = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.User = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.export = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1351, 1321);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(539, 138);
            this.button1.TabIndex = 0;
            this.button1.Text = "Import File";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.importfile);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(112, 87);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 29);
            this.label1.TabIndex = 1;
            // 
            // Stop
            // 
            this.Stop.Location = new System.Drawing.Point(1750, 1466);
            this.Stop.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Stop.Name = "Stop";
            this.Stop.Size = new System.Drawing.Size(114, 54);
            this.Stop.TabIndex = 2;
            this.Stop.Text = "■";
            this.Stop.UseVisualStyleBackColor = true;
            this.Stop.Click += new System.EventHandler(this.Stop_Click);
            // 
            // Play
            // 
            this.Play.Location = new System.Drawing.Point(1379, 1466);
            this.Play.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Play.Name = "Play";
            this.Play.Size = new System.Drawing.Size(114, 54);
            this.Play.TabIndex = 4;
            this.Play.Text = "▶";
            this.Play.UseVisualStyleBackColor = true;
            this.Play.Click += new System.EventHandler(this.Play_Click);
            // 
            // volup
            // 
            this.volup.Font = new System.Drawing.Font("Microsoft Sans Serif", 5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.volup.Location = new System.Drawing.Point(1570, 1463);
            this.volup.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.volup.Name = "volup";
            this.volup.Size = new System.Drawing.Size(100, 25);
            this.volup.TabIndex = 5;
            this.volup.Text = "up";
            this.volup.UseVisualStyleBackColor = true;
            this.volup.Click += new System.EventHandler(this.volumeup);
            // 
            // voldown
            // 
            this.voldown.Font = new System.Drawing.Font("Microsoft Sans Serif", 5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.voldown.Location = new System.Drawing.Point(1570, 1492);
            this.voldown.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.voldown.Name = "voldown";
            this.voldown.Size = new System.Drawing.Size(100, 25);
            this.voldown.TabIndex = 6;
            this.voldown.Text = "down";
            this.voldown.UseVisualStyleBackColor = true;
            this.voldown.Click += new System.EventHandler(this.volumedown);
            // 
            // volume
            // 
            this.volume.AutoSize = true;
            this.volume.Font = new System.Drawing.Font("Microsoft Sans Serif", 28F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.volume.Location = new System.Drawing.Point(12, 9);
            this.volume.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.volume.Name = "volume";
            this.volume.Size = new System.Drawing.Size(136, 95);
            this.volume.TabIndex = 7;
            this.volume.Text = "50";
            this.volume.Visible = false;
            this.volume.Click += new System.EventHandler(this.label2_Click);
            // 
            // Search
            // 
            this.Search.Location = new System.Drawing.Point(1374, 29);
            this.Search.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Search.Name = "Search";
            this.Search.Size = new System.Drawing.Size(501, 35);
            this.Search.TabIndex = 10;
            this.Search.Text = "Search";
            this.Search.TextChanged += new System.EventHandler(this.Search_TextChanged);
            // 
            // Account
            // 
            this.Account.Location = new System.Drawing.Point(2611, 11);
            this.Account.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Account.Name = "Account";
            this.Account.Size = new System.Drawing.Size(215, 67);
            this.Account.TabIndex = 11;
            this.Account.Text = "Account";
            this.Account.UseVisualStyleBackColor = true;
            this.Account.Click += new System.EventHandler(this.Account_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(2038, 14);
            this.button2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(215, 67);
            this.button2.TabIndex = 12;
            this.button2.Text = "Upload";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.upload_Click);
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ID,
            this.Title,
            this.User});
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(425, 98);
            this.listView1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.listView1.Name = "listView1";
            this.listView1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.listView1.Size = new System.Drawing.Size(2400, 1200);
            this.listView1.TabIndex = 13;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // ID
            // 
            this.ID.Text = "ID";
            this.ID.Width = 800;
            // 
            // Title
            // 
            this.Title.Text = "File Name";
            this.Title.Width = 800;
            // 
            // User
            // 
            this.User.Text = "User";
            this.User.Width = 800;
            // 
            // export
            // 
            this.export.Location = new System.Drawing.Point(425, 11);
            this.export.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.export.Name = "export";
            this.export.Size = new System.Drawing.Size(222, 67);
            this.export.TabIndex = 14;
            this.export.Text = "Export File";
            this.export.UseVisualStyleBackColor = true;
            this.export.Click += new System.EventHandler(this.export_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(653, 31);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 29);
            this.label2.TabIndex = 15;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(1881, 27);
            this.button3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 40);
            this.button3.TabIndex = 16;
            this.button3.Text = "🔎";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Player
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(3172, 1521);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.export);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.Account);
            this.Controls.Add(this.Search);
            this.Controls.Add(this.volume);
            this.Controls.Add(this.voldown);
            this.Controls.Add(this.volup);
            this.Controls.Add(this.Play);
            this.Controls.Add(this.Stop);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.Name = "Player";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Player_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Stop;
        private System.Windows.Forms.Button Play;
        private System.Windows.Forms.Button volup;
        private System.Windows.Forms.Button voldown;
        private System.Windows.Forms.Label volume;
        private System.Windows.Forms.TextBox Search;
        private System.Windows.Forms.Button Account;
        private System.Windows.Forms.Button button2;

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader ID;
        private System.Windows.Forms.ColumnHeader Title;
        private System.Windows.Forms.ColumnHeader User;
        private System.Windows.Forms.Button export;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button3;
    }
}

