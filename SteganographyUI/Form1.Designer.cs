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
            this.menuStrip1.SuspendLayout();
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
            this.menuStrip1.Size = new System.Drawing.Size(610, 24);
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
            this.algoritmToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.algoritmToolStripMenuItem.Text = "Algoritm";
            // 
            // algo1ToolStripMenuItem
            // 
            this.algo1ToolStripMenuItem.Checked = true;
            this.algo1ToolStripMenuItem.CheckOnClick = true;
            this.algo1ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.algo1ToolStripMenuItem.Name = "algo1ToolStripMenuItem";
            this.algo1ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.algo1ToolStripMenuItem.Text = "Algo1";
            this.algo1ToolStripMenuItem.Click += new System.EventHandler(this.algo1ToolStripMenuItem_Click);
            // 
            // algo2ToolStripMenuItem
            // 
            this.algo2ToolStripMenuItem.Name = "algo2ToolStripMenuItem";
            this.algo2ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.algo2ToolStripMenuItem.Text = "Algo2";
            this.algo2ToolStripMenuItem.Click += new System.EventHandler(this.algo2ToolStripMenuItem_Click);
            // 
            // setariToolStripMenuItem
            // 
            this.setariToolStripMenuItem.Name = "setariToolStripMenuItem";
            this.setariToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
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
            this.ajutorToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.ajutorToolStripMenuItem.Text = "Ajutor";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(610, 264);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Steganografie";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
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
    }
}

