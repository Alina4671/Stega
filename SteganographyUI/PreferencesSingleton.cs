using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteganographyUI
{
    public class PreferencesSingleton
    {
        private PreferencesSingleton()
        {

        }
        private static PreferencesSingleton preferencesInstance = null;
        public static PreferencesSingleton Instance
        {
            get
            {
                if (preferencesInstance == null)
                {
                    preferencesInstance = new PreferencesSingleton();
                }
                return preferencesInstance;
            }
        }

        public Boolean AutoSave { get; set; }
        public Boolean UsePassword { get; set; }
        public String Password { get; set; }
        public String ImagePath { get; set; }
        public String HiddenImagePath { get; set; }
        public EAlgoSelect SelectedAlgorithm { get; set; }
        public String PlainText { get; set; }
        public byte EncodingDataIndex { get; set; }
    }
}
