using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GLib.data.schema
{
    public class GSqlParam: GSqlField
    {
        
        // -----------------------------------------------------------------------------------------------------------------------------         
        public GSqlParam(string p_sName, Type p_tDType): base()
        {
            this.Name   = p_sName;
            this.DType  = p_tDType;
            this.determineDBType();
        }
        // -----------------------------------------------------------------------------------------------------------------------------         
        protected void determineDBType()
        {
            if (DType == typeof(int))
                DBType = SqlDbType.Int;
            else if (DType == typeof(int?))
                DBType = SqlDbType.Int;
            else if (DType == typeof(long))
                DBType = SqlDbType.BigInt;
            else if (DType == typeof(long?))
                DBType = SqlDbType.BigInt;
            else if (DType == typeof(Int16))
                DBType = SqlDbType.SmallInt;
            else if (DType == typeof(Int16?))
                DBType = SqlDbType.SmallInt;
            else if (DType == typeof(byte))
                DBType = SqlDbType.TinyInt;
            else if (DType == typeof(byte?))
                DBType = SqlDbType.TinyInt;
            else if (DType == typeof(float))
                DBType = SqlDbType.Float;
            else if (DType == typeof(float?))
                DBType = SqlDbType.Float;
            else if (DType == typeof(double))
                DBType = SqlDbType.Float;
            else if (DType == typeof(double?))
                DBType = SqlDbType.Float;
            else if (DType == typeof(DateTime))
                DBType = SqlDbType.DateTime;
            else if (DType == typeof(DateTime?))
                DBType = SqlDbType.DateTime;
            else if (DType == typeof(string))
                DBType = SqlDbType.NVarChar;

        }
        // -----------------------------------------------------------------------------------------------------------------------------         
    }
}
