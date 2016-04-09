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

        public Boolean AutoSave;
        public Boolean UsePassword;
        public String Password;
    }
}
