using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using SteganographyDll;
using System.Drawing;
using System.Windows.Forms;

namespace SteganographyUI
{
    public class MessageEncoder : StegaWorker
    {
        private static MessageEncoder instance = null;
        private MessageEncoder() { }
        public static MessageEncoder Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MessageEncoder();
                }
                return instance;
            }
        }


        private Image image = null;
        public Image GetImage()
        {
            return image;
        }


        public override void Work()
        {
            string encryptedText = "";
            image = Image.FromFile(prefsInstance.ImagePath);
            byte[] hiddenArrayBytes = null;
            switch(prefsInstance.EncodingDataIndex)
            {
                case 0x01:
                    {

                        if (prefsInstance.UsePassword == true)
                        {
                            encryptedText = Crypto.EncryptStringAES(prefsInstance.PlainText, prefsInstance.Password);
                        }
                        else
                        {
                            encryptedText = prefsInstance.PlainText;
                        }
                        hiddenArrayBytes = Encoding.ASCII.GetBytes(encryptedText);
                    }
                    break;
                case 0x02:
                    {
                        hiddenArrayBytes = Utils.BitmapToByteArray(Image.FromFile(prefsInstance.HiddenImagePath));
                    }
                    break;
                default:
                    MessageBox.Show("Completati campurile din setari!", "Atentie!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

            }            
            AlgoFormatImpl = stegaFactory.GetImplementationByFormat(ESupportedAlgorithms.ClasicAlgo);

            AlgoFormatImpl.Encode(ref image, hiddenArrayBytes);
            OnWorkDone(EventArgs.Empty);

        }

        public override StegaWorker SetPreferences(PreferencesSingleton prefsInstance)
        {
            this.prefsInstance = prefsInstance;
            switch (prefsInstance.SelectedAlgorithm)
            {
                case EAlgoSelect.E_BATTLESEG_ALGO:
                    break;
                case EAlgoSelect.E_STEGA_ALGO:
                    {
                        AlgoFormatImpl = stegaFactory.GetImplementationByFormat(ESupportedAlgorithms.ClasicAlgo);
                    }
                    break;
                default:
                    break;
            }
            return this;
        }
    }
}
