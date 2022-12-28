using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace GLib.data.schema
{
    public class GSqlFieldDict: Dictionary<string, GSqlField>
    {
        public GParamSchemaKind Kind { get; set; }

        // -----------------------------------------------------------------------------------------------------------------------------         
        public GSqlFieldDict()
        {
            Kind = GParamSchemaKind.FIELDS_AND_KEY;
        }
        // -----------------------------------------------------------------------------------------------------------------------------         
        public void Add(string p_sName, string p_sSQLName, SqlDbType p_oType)
        {
            this[p_sName] = new GSqlField() { Name = p_sSQLName, DBType = p_oType };
        }
        // -----------------------------------------------------------------------------------------------------------------------------         

    }
}
