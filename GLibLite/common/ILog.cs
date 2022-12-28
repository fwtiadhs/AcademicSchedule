using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GLib.common
{
    public interface ILog
    {
        bool HasError { get; }

        public string LastError { get; set; }
        void WriteErrorLine(string p_sErrorLine);
        void WriteLine(string p_sLine);
        void Write(string p_sText);
    }


    
}
