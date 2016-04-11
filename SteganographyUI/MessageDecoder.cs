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
    public class MessageDecoder: StegaWorker
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


        private String decodedText=null;
        public String GetDecodedText()
        {
            return decodedText;
        }
      
        public override void Work()
        {
            Bitmap image = new Bitmap(prefsInstance.ImagePath);
            switch (prefsInstance.SelectedAlgorithm)
            {
                case EAlgoSelect.E_BATTLESEG_ALGO:
                    break;
                case EAlgoSelect.E_STEGA_ALGO:
                    {
                        format = stegaFactory.GetImplementationByFormat(ESupportedFormats.BmpFormat);
                        format.Decode(image, ref decodedText);
                        OnWorkDone(EventArgs.Empty);
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
