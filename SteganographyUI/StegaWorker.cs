using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SteganographyDll;
namespace SteganographyUI
{
    public abstract class StegaWorker
    {
        protected SteganographyAbstractFactory stegaFactory = SteganographyProducer.GetFactory();
        protected ISteganographyFormats format;
        protected PreferencesSingleton prefsInstance = null;

        protected static StegaWorker instance = null;
        protected StegaWorker() { }
        public abstract void Work();
        public abstract StegaWorker SetPreferences(PreferencesSingleton prefsInstance);
    }
}
