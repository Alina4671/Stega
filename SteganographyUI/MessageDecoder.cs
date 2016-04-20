using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using SteganographyDll;
using System.Drawing;
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


        private String decodedText = null;
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

            AlgoFormatImpl = stegaFactory.GetImplementationByFormat(ESupportedAlgorithms.ClasicAlgo);
            byte[] byteArrayText = null;
            AlgoFormatImpl.Decode(image, ref byteArrayText);
            if (prefsInstance.EncodingDataIndex == 0x01)
            {
                decodedText = Encoding.Default.GetString(byteArrayText);
            }
            else
            {
                if (prefsInstance.EncodingDataIndex == 0x02)
                {
                    decodedImage = Utils.ByteArrayToBitmap(byteArrayText);
                }
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
