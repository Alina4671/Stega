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

       
        protected StegaWorker() { }
        public event EventHandler WorkDone;

        public abstract void Work();
        public abstract StegaWorker SetPreferences(PreferencesSingleton prefsInstance);
        protected virtual void OnWorkDone(EventArgs e)
        {
            EventHandler handler = WorkDone;
            if(handler!=null)
            {
                handler(this, e);
            }
        }
    }
}
