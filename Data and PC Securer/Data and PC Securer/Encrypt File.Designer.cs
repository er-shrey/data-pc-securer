namespace Data_and_PC_Securer
{
    partial class Encrypt_File
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Encrypt_File));
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.unselectall = new System.Windows.Forms.CheckBox();
            this.selectall = new System.Windows.Forms.CheckBox();
            this.mycheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnChange = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button2.BackgroundImage")));
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.Location = new System.Drawing.Point(186, 376);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(453, 32);
            this.button2.TabIndex = 27;
            this.button2.Text = "Encrypt";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackgroundImage = global::Data_and_PC_Securer.Properties.Resources.background1;
            this.groupBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.groupBox1.Controls.Add(this.unselectall);
            this.groupBox1.Controls.Add(this.selectall);
            this.groupBox1.Location = new System.Drawing.Point(13, 62);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(167, 118);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Selection Type";
            // 
            // unselectall
            // 
            this.unselectall.AutoSize = true;
            this.unselectall.BackColor = System.Drawing.Color.Transparent;
            this.unselectall.Location = new System.Drawing.Point(17, 71);
            this.unselectall.Name = "unselectall";
            this.unselectall.Size = new System.Drawing.Size(82, 17);
            this.unselectall.TabIndex = 1;
            this.unselectall.Text = "Unselect All";
            this.unselectall.UseVisualStyleBackColor = false;
            this.unselectall.CheckedChanged += new System.EventHandler(this.unselectall_CheckedChanged);
            // 
            // selectall
            // 
            this.selectall.AutoSize = true;
            this.selectall.BackColor = System.Drawing.Color.Transparent;
            this.selectall.Location = new System.Drawing.Point(17, 34);
            this.selectall.Name = "selectall";
            this.selectall.Size = new System.Drawing.Size(70, 17);
            this.selectall.TabIndex = 0;
            this.selectall.Text = "Select All";
            this.selectall.UseVisualStyleBackColor = false;
            this.selectall.CheckedChanged += new System.EventHandler(this.selectall_CheckedChanged);
            // 
            // mycheckedListBox
            // 
            this.mycheckedListBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.mycheckedListBox.CheckOnClick = true;
            this.mycheckedListBox.FormattingEnabled = true;
            this.mycheckedListBox.Location = new System.Drawing.Point(186, 62);
            this.mycheckedListBox.Name = "mycheckedListBox";
            this.mycheckedListBox.Size = new System.Drawing.Size(453, 304);
            this.mycheckedListBox.TabIndex = 21;
            // 
            // btnDel
            // 
            this.btnDel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDel.BackgroundImage")));
            this.btnDel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDel.Location = new System.Drawing.Point(347, 2);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(134, 44);
            this.btnDel.TabIndex = 24;
            this.btnDel.Text = "Delete from List";
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnOpen.BackgroundImage")));
            this.btnOpen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnOpen.Location = new System.Drawing.Point(13, 2);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(134, 44);
            this.btnOpen.TabIndex = 23;
            this.btnOpen.Text = "&Open";
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnChange
            // 
            this.btnChange.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnChange.BackgroundImage")));
            this.btnChange.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnChange.Location = new System.Drawing.Point(180, 2);
            this.btnChange.Name = "btnChange";
            this.btnChange.Size = new System.Drawing.Size(134, 44);
            this.btnChange.TabIndex = 22;
            this.btnChange.Text = "Clear List";
            this.btnChange.Click += new System.EventHandler(this.btnChange_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Uni Cipher",
            "DES",
            "AES"});
            this.comboBox1.Location = new System.Drawing.Point(30, 238);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(133, 21);
            this.comboBox1.TabIndex = 28;
            this.comboBox1.Text = "DES";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(27, 212);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 29;
            this.label1.Text = "Encryption Type:";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Multiselect = true;
            // 
            // Encrypt_File
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Data_and_PC_Securer.Properties.Resources.background1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(652, 410);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.mycheckedListBox);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.btnChange);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Encrypt_File";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Encrypt File";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox unselectall;
        private System.Windows.Forms.CheckBox selectall;
        private System.Windows.Forms.CheckedListBox mycheckedListBox;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnChange;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}