using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Drawing.Imaging;
namespace SteganographyUI
{
    public partial class Form1 : Form
    {
        private PreferencesSingleton preferences = PreferencesSingleton.Instance;
        
        private readonly OpenFileDialog OpenDialog = new OpenFileDialog();
        private SaveFileDialog SaveDialog = new SaveFileDialog();
        
        public Form1()
        {
            InitializeComponent();
            preferences.SelectedAlgorithm = EAlgoSelect.E_STEGA_ALGO;
        }

        private void selecteazaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenDialog.Filter = "PNG Images|*.png|BMP Images|*.bmp|JPG Images|*.jpg";
            OpenDialog.FilterIndex = 1;

            OpenDialog.Multiselect = false;
            DialogResult result = OpenDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                preferences.ImagePath = OpenDialog.InitialDirectory + OpenDialog.FileName;
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox1.ImageLocation = preferences.ImagePath;
            }
        }

        private void salveazaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveDialog.Filter = "PNG Images|*.png|BMP Images|*.bmp|JPG Images|*.jpg";
            SaveDialog.Title = "Salveaza";
            SaveDialog.ShowDialog();

            if (SaveDialog.FileName != "")
            {

                FileStream fs =
                   (FileStream)SaveDialog.OpenFile();

                switch (SaveDialog.FilterIndex)
                {
                    case 1:

                        this.salveazaToolStripMenuItem.Image.Save(fs,
                           ImageFormat.Png);
                        break;

                    case 2:
                        this.salveazaToolStripMenuItem.Image.Save(fs,
                           ImageFormat.Bmp);
                        break;

                    case 3:
                        this.salveazaToolStripMenuItem.Image.Save(fs,
                           ImageFormat.Jpeg);
                        break;
                }

                fs.Close();
            }
        }

        private void setariToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Preferinte pf = new Preferinte();
            pf.ShowDialog();
        }


        private void algo1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            switch (preferences.SelectedAlgorithm)
            {
                case EAlgoSelect.E_STEGA_ALGO:

                    break;
                case EAlgoSelect.E_BATTLESEG_ALGO:
                    preferences.SelectedAlgorithm = EAlgoSelect.E_STEGA_ALGO;
                    algo1ToolStripMenuItem.CheckState = CheckState.Checked;
                    algo2ToolStripMenuItem.CheckState = CheckState.Unchecked;
                    break;
                default: break;
            }
        }

        private void algo2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            switch (preferences.SelectedAlgorithm)
            {
                case EAlgoSelect.E_STEGA_ALGO:
                    preferences.SelectedAlgorithm = EAlgoSelect.E_BATTLESEG_ALGO;
                    algo2ToolStripMenuItem.CheckState = CheckState.Checked;
                    algo1ToolStripMenuItem.CheckState = CheckState.Unchecked;
                    break;
                case EAlgoSelect.E_BATTLESEG_ALGO: break;
                default: break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void ajutorToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }



}
