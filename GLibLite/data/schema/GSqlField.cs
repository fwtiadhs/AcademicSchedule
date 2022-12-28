using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GLib.data.schema
{
    public class GSqlField
    {
        public string           Name { get; set; }

        public string           PropertyName { get; set; }
        public Type             DType { get; set; }

        public SqlDbType        DBType { get; set; }

        public object           Value { get; set; }


        public GSqlField()
        {
            this.Name           = String.Empty;
            this.PropertyName   = null;
            this.DBType = SqlDbType.Int;
            this.DType  = null;
            this.Value  = null;
        }

    }
}
