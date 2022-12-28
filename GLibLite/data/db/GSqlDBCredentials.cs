using Glib.data.files;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GLib.data.db
{
    // ===============================================================================================================================
    public class GSqlDBCredentials
    {
        // ....................................................................
        public string DBServer { get; set; }
        // ....................................................................
        public string DBHost { get; set; }
        // ....................................................................
        public int DBPort { get; set; }
        // ....................................................................
        public string DBName { get; set; }
        // ....................................................................
        public string DBUser { get; set; }
        // ....................................................................
        public string DBPassword { get; set; }
        // ....................................................................

        
        //------------------------------------------------------------------------------
        public GSqlDBCredentials()
        {
            this.DBPort = 1433;
        }
        //------------------------------------------------------------------------------
        public string GetConnectionString()
        {
            string sResult;


            string sFormat = "Data Source={0} ;Initial Catalog={1}; User ID={2}; Password={3}; Connect Timeout = 30; Encrypt = False; " +
                      "TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";

            sResult = String.Format(sFormat, this.DBServer, this.DBName, this.DBUser, this.DBPassword);

            //sResult = "Data Source=ARGO\\MSSQL2017;Initial Catalog=union_optic;User ID=union;Password=union100%go;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            return sResult;
        }
        //------------------------------------------------------------------------------
        public static GSqlDBCredentials LoadFromFile(string p_sFileName)
        {
            GSqlDBCredentials oResult = null;
            try
            { 
                GJsonFile oConfigFile = new GJsonFile(p_sFileName);
                oConfigFile.ClassType = typeof(GSqlDBCredentials);
                oResult = (GSqlDBCredentials)oConfigFile.Load();
                return oResult;
            }
            catch(Exception E)
            {
                throw new Exception(String.Format("Error loading DB configuration from {0}: {1}", p_sFileName, E.Message));
            }
        }
        //------------------------------------------------------------------------------
    }
}
