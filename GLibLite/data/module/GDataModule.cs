using GLib.data.db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace GLib.data.module
{
    public class GDataModule: IDataModule
    {
        // ......................................................................................................
        public static GSqlDBCredentials DBCredentials { get; set; }
        // ......................................................................................................
        private static GSqlDB __commonDB = null;
        public static GSqlDB CommonDB
        {
            get
            {
                if (__commonDB == null)
                    __commonDB = new GSqlDB(DBCredentials);
                
                if (!__commonDB.IsConnected)
                    __commonDB.Connect();
                return __commonDB;
            }
        }
        // ......................................................................................................


        protected GSqlDB db = null;
        
        // -----------------------------------------------------------------------------------------------------------------------------
        public GDataModule()
        {
            establishConnection();
        }
        // -----------------------------------------------------------------------------------------------------------------------------
        public virtual bool LoadRecordsTo(object p_oDestObject)
        {
            bool bResult = false;
            return bResult;
        }
        // -----------------------------------------------------------------------------------------------------------------------------
        public virtual bool Load()
        {
            bool bResult = false;
            return bResult;

        }
        // -----------------------------------------------------------------------------------------------------------------------------
        public virtual bool Save()
        {
            bool bResult = false;
            return bResult;
        }
        // -----------------------------------------------------------------------------------------------------------------------------
        private bool establishConnection()
        {   

            bool bResult = true;
            if (this.db == null)
            { 
                try
                {
                    this.db = GDataModule.CommonDB;
                }
                catch (Exception E)
                {
                    this.db.Log.WriteErrorLine("Error connecting: " + E.Message);
                    this.db = null;
                    bResult = false;
                }
            }
            return bResult;
        }
        // -----------------------------------------------------------------------------------------------------------------------------
    }
}
