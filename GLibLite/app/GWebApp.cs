using GLib.data.db;
using GLib.data.module;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GLib.app
{
    public class GWebApp
    {
        // ......................................................................................................
        public static GSqlDBCredentials DBCredentials 
        {   get { return GDataModule.DBCredentials; }
            set { GDataModule.DBCredentials = value;}
        }
        // ......................................................................................................
        private static GWebApp __instance = null;

        public static GWebApp Instance
        {
            get
            {
                if (__instance == null)
                    __instance = new GWebApp();
                return __instance;
            }
        }
        // ......................................................................................................

        public GSqlDB DB { get { return GDataModule.CommonDB; } }

        // ......................................................................................................
    }
}
