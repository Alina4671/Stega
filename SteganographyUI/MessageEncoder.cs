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

        private MessageEncoder() { }
        public static MessageEncoder Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MessageEncoder();
                }
                return (MessageEncoder)instance;
            }
        }


        private Bitmap image = null;
        public Bitmap GetImage()
        {
            return image;
        }


        public override void Work()
        {
            image = new Bitmap(prefsInstance.ImagePath);
            switch (prefsInstance.SelectedAlgorithm)
            {
                case EAlgoSelect.E_BATTLESEG_ALGO:
                    break;
                case EAlgoSelect.E_STEGA_ALGO:
                    {
                        format = stegaFactory.GetImplementationByFormat(ESupportedFormats.BmpFormat);

                        format.Encode(ref image, prefsInstance.PlainText);
                    }
                    break;
                default:
                    break;
            }
        }

        public override StegaWorker SetPreferences(PreferencesSingleton prefsInstance)
        {
            this.prefsInstance = prefsInstance;
            return this;
        }
    }
}
