namespace SteganographyUI
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.imagineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selecteazaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salveazaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.preferinteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.algoritmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.algo1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.algo2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setariToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.despreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ajutorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.imagineToolStripMenuItem,
            this.preferinteToolStripMenuItem,
            this.despreToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(712, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // imagineToolStripMenuItem
            // 
            this.imagineToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selecteazaToolStripMenuItem,
            this.salveazaToolStripMenuItem});
            this.imagineToolStripMenuItem.Name = "imagineToolStripMenuItem";
            this.imagineToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.I)));
            this.imagineToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.imagineToolStripMenuItem.Text = "Imagine";
            // 
            // selecteazaToolStripMenuItem
            // 
            this.selecteazaToolStripMenuItem.Name = "selecteazaToolStripMenuItem";
            this.selecteazaToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.selecteazaToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.selecteazaToolStripMenuItem.Text = "Selecteaza";
            this.selecteazaToolStripMenuItem.Click += new System.EventHandler(this.selecteazaToolStripMenuItem_Click);
            // 
            // salveazaToolStripMenuItem
            // 
            this.salveazaToolStripMenuItem.Name = "salveazaToolStripMenuItem";
            this.salveazaToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.salveazaToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.salveazaToolStripMenuItem.Text = "Salveaza";
            this.salveazaToolStripMenuItem.Click += new System.EventHandler(this.salveazaToolStripMenuItem_Click);
            // 
            // preferinteToolStripMenuItem
            // 
            this.preferinteToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.algoritmToolStripMenuItem,
            this.setariToolStripMenuItem});
            this.preferinteToolStripMenuItem.Name = "preferinteToolStripMenuItem";
            this.preferinteToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
            this.preferinteToolStripMenuItem.Text = "Preferinte";
            // 
            // algoritmToolStripMenuItem
            // 
            this.algoritmToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.algo1ToolStripMenuItem,
            this.algo2ToolStripMenuItem});
            this.algoritmToolStripMenuItem.Name = "algoritmToolStripMenuItem";
            this.algoritmToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.algoritmToolStripMenuItem.Text = "Algoritm";
            // 
            // algo1ToolStripMenuItem
            // 
            this.algo1ToolStripMenuItem.Checked = true;
            this.algo1ToolStripMenuItem.CheckOnClick = true;
            this.algo1ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.algo1ToolStripMenuItem.Name = "algo1ToolStripMenuItem";
            this.algo1ToolStripMenuItem.Size = new System.Drawing.Size(105, 22);
            this.algo1ToolStripMenuItem.Text = "Algo1";
            this.algo1ToolStripMenuItem.Click += new System.EventHandler(this.algo1ToolStripMenuItem_Click);
            // 
            // algo2ToolStripMenuItem
            // 
            this.algo2ToolStripMenuItem.Name = "algo2ToolStripMenuItem";
            this.algo2ToolStripMenuItem.Size = new System.Drawing.Size(105, 22);
            this.algo2ToolStripMenuItem.Text = "Algo2";
            this.algo2ToolStripMenuItem.Click += new System.EventHandler(this.algo2ToolStripMenuItem_Click);
            // 
            // setariToolStripMenuItem
            // 
            this.setariToolStripMenuItem.Name = "setariToolStripMenuItem";
            this.setariToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.setariToolStripMenuItem.Text = "Setari";
            this.setariToolStripMenuItem.Click += new System.EventHandler(this.setariToolStripMenuItem_Click);
            // 
            // despreToolStripMenuItem
            // 
            this.despreToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ajutorToolStripMenuItem});
            this.despreToolStripMenuItem.Name = "despreToolStripMenuItem";
            this.despreToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.despreToolStripMenuItem.Text = "Despre";
            // 
            // ajutorToolStripMenuItem
            // 
            this.ajutorToolStripMenuItem.Name = "ajutorToolStripMenuItem";
            this.ajutorToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.ajutorToolStripMenuItem.Text = "Ajutor";
            this.ajutorToolStripMenuItem.Click += new System.EventHandler(this.ajutorToolStripMenuItem_Click);
            // 
            // button2
            // 
            this.button2.BackgroundImage = global::SteganographyUI.Properties.Resources.Lock_Unlock_icon;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button2.Location = new System.Drawing.Point(12, 169);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(302, 71);
            this.button2.TabIndex = 3;
            this.button2.Text = "Extragere mesaj";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::SteganographyUI.Properties.Resources.Lock_icon;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1.Location = new System.Drawing.Point(12, 79);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(302, 71);
            this.button1.TabIndex = 2;
            this.button1.Text = "Ascundere mesaj";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::SteganographyUI.Properties.Resources._6a0147e41f3c0a970b015435e9654a970c_800wi1;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(338, 28);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(359, 212);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 328);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(684, 18);
            this.progressBar1.TabIndex = 5;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(13, 247);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(684, 62);
            this.richTextBox1.TabIndex = 6;
            this.richTextBox1.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(712, 358);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Steganografie";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem imagineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selecteazaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salveazaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem preferinteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem algoritmToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem algo1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem algo2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setariToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem despreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ajutorToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}

