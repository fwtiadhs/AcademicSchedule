using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GLib.data.schema
{
    public enum GParamSchemaKind
    {
         KEY_ONLY         = 1
        ,FIELDS_ONLY      = 2
        ,FIELDS_AND_KEY   = 3
        ,FOREIGN_KEY_ONLY = 4
    }
}
