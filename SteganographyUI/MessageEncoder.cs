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

            image = Image.FromFile(prefsInstance.ImagePath);
            byte[] hiddenArrayBytes = null;
            if (prefsInstance.EncodingDataIndex == 0x01)
            {
                hiddenArrayBytes = Encoding.ASCII.GetBytes(prefsInstance.PlainText);
            }
            else
            {
                if (prefsInstance.EncodingDataIndex == 0x02)
                {
                    hiddenArrayBytes = Utils.BitmapToByteArray(Image.FromFile(prefsInstance.HiddenImagePath));
                }
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
