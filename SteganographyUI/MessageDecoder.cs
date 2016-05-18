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
    public class MessageDecoder : StegaWorker
    {

        private static MessageDecoder instance = null;
        private MessageDecoder() { }
        public static MessageDecoder Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MessageDecoder();
                }
                return instance;
            }
        }


        private String decodedText = "";
        private Image decodedImage = null;
        public String GetDecodedText()
        {
            return decodedText;
        }
        public Image GetDecodedImage()
        {
            return decodedImage;
        }

        public override void Work()
        {
            Image image = Image.FromFile(prefsInstance.ImagePath);
            string cipherText = "";
            AlgoFormatImpl = stegaFactory.GetImplementationByFormat(ESupportedAlgorithms.ClasicAlgo);
            byte[] byteArrayText = null;
            AlgoFormatImpl.Decode(image, ref byteArrayText);
            switch (prefsInstance.EncodingDataIndex)
            {
                case 0x01:
                    {
                        cipherText = Encoding.Default.GetString(byteArrayText);
                        if (prefsInstance.UsePassword == true)
                        {
                            decodedText = Crypto.DecryptStringAES(cipherText, prefsInstance.Password);
                        }
                        else
                        {
                            decodedText = cipherText;
                        }
                    }
                    break;
                case 0x02:
                    {
                        if (prefsInstance.EncodingDataIndex == 0x02)//image decoding
                        {
                            decodedImage = Utils.ByteArrayToBitmap(byteArrayText);
                        }
                    }
                    break;
                default:
                  MessageBox.Show("Completati campurile din setari!","Atentie!",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    return;
                    
            }

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
                        OnWorkDone(EventArgs.Empty);
                    }
                    break;
                default:
                    break;
            }
            return this;
        }
    }
}
