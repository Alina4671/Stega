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
using SteganographyDll;
namespace SteganographyUI
{
    public partial class Form1 : Form
    {
        private PreferencesSingleton preferences = PreferencesSingleton.Instance;

        private readonly OpenFileDialog OpenDialog = new OpenFileDialog();
        private SaveFileDialog SaveDialog = new SaveFileDialog();

        private ISteganographyAlgorithms format;
        private readonly String[] m_SupportedExtensions = { ".bmp", ".png", ".jpg" };
        private Bitmap m_EncodedImage;
        private StegaWorker worker = null;
        private Image encodedImage = null;
     

        private Preferinte pf;

        public Form1()
        {
            
            InitializeComponent();
            initUiComponentsDefaultStates();
        }

        private void initUiComponentsDefaultStates()
        {
            preferences.SelectedAlgorithm = EAlgoSelect.E_STEGA_ALGO;
            button1.Enabled = false;
            button2.Enabled = false;
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
                button1.Enabled = true;
                button2.Enabled = true;
                
            }
        }

        private void salveazaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (encodedImage == null)
            {
                return;
            }
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

                        encodedImage.Save(fs,
                           ImageFormat.Png);
                        break;

                    case 2:
                        encodedImage.Save(fs,
                           ImageFormat.Bmp);
                        break;

                    case 3:
                        encodedImage.Save(fs,
                           ImageFormat.Jpeg);
                        break;
                }

                fs.Close();
            }
        }

        private void setariToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pf = new Preferinte();
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

         
            worker = MessageEncoder.Instance.SetPreferences(preferences);
            worker.WorkDone += OnEncodeDone;
            format =((MessageEncoder) worker).AlgoFormatImpl;
            format.ProgressUpdateEncode += OnEncodeProgressUpdate;
            Thread encodingThread = new Thread(worker.Work);
            encodingThread.Start();


          

        }

        private void OnEncodeProgressUpdate(object sender, ProgressNotification e)
        {
            progressBar1.Value = e.EncodeProgress;
        }

        private void ajutorToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            worker = MessageDecoder.Instance.SetPreferences(preferences);
            worker.WorkDone += OnDecodeDone;
            format = worker.AlgoFormatImpl;
            format.ProgressUpdateDecode += OnDecodeProgressUpdate;
            Thread decodingThread = new Thread(worker.Work);
            decodingThread.Start();


        }

        private void OnDecodeProgressUpdate(object sender, ProgressNotification e)
        {
            progressBar1.Value = e.DecodeProgress;
        }

        private void OnEncodeDone(object sender, EventArgs e)
        {
            encodedImage = ((MessageEncoder)worker).GetImage();
            if(preferences.AutoSave==true)
            {
                
                //FileStream fs = File.Open(preferences.ImagePath, FileMode.Open, FileAccess.Write, FileShare.Read);
                    //new FileStream(preferences.ImagePath, FileMode.Open);
                    
                string imageExtension = Path.GetExtension(preferences.ImagePath);
                switch(imageExtension)
                {
                    case ".bmp":
                        Image saved = new Bitmap(encodedImage);
                        encodedImage.Dispose();
                        encodedImage = null;
                        saved.Save(preferences.ImagePath,ImageFormat.Bmp);
                        break;
                    case ".png":
                        encodedImage.Save(preferences.ImagePath,
                          ImageFormat.Png);
                        break;
                    case ".jpg":
                        encodedImage.Save(preferences.ImagePath,
                          ImageFormat.Jpeg);
                        break;
                    default:
                        break;
                }
                
            }
            MessageBox.Show("Ascunderea mesajului s-a terminat!");
        }
    
        private void OnDecodeDone(object sender, EventArgs e)
        {
            if(preferences.EncodingDataIndex==0x01)
            {
                String decodedText = ((MessageDecoder)worker).GetDecodedText();
                decodedText=decodedText.Trim('\t');
                if(String.IsNullOrEmpty(decodedText))
                {
                    label1.ForeColor = System.Drawing.Color.Red;
                    decodedText = "Extragerea mesajului nereusita!";
                    
                }
                foreach(char c in decodedText.ToCharArray())
                {
                    if(char.IsControl(c) )
                    {
                        label1.ForeColor = System.Drawing.Color.Red;
                        decodedText = "Extragerea mesajului nereusita!";
                        break;
                    }
                }

                Invoke(new Action(() => label1.Text = decodedText));
            }
            else
            {
                if(preferences.EncodingDataIndex==0x02)
                {
                    
                    Invoke(new Action(() => pictureBox1.Image = ((MessageDecoder)worker).GetDecodedImage()));
                    
                   
                }
            }
            MessageBox.Show("Extragerea mesajului s-a terminat!");
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }


    }



}
