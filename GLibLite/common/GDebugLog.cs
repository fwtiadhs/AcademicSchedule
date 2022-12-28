using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace GLib.common
{
    public class GDebugLog: ILog
    {
        public const string LOG_LINE_TEMPLATE = "|__ [{0}] {1}";

        private string __lastError = String.Empty;
        public string LastError { get { return __lastError;} set { __lastError = value; } }

        public bool HasError { get { return __lastError != String.Empty;} }

        //------------------------------------------------------------------------------
        public void WriteErrorLine(string p_sErrorLine)
        {
            __lastError = p_sErrorLine;
            this.WriteLine(p_sErrorLine);
        }
        //------------------------------------------------------------------------------
        public void WriteLine(string p_sLine)
        {
            Debug.WriteLine(String.Format(LOG_LINE_TEMPLATE, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), p_sLine));
        }
        //------------------------------------------------------------------------------
        public void Write(string p_sText)
        {
            Debug.Write(p_sText);
        }
        //------------------------------------------------------------------------------
    }
}
