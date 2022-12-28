using System.Collections.Generic;
using System.Data;

namespace GLib.data.db
{
    // ===============================================================================================================================
    public interface IQueryToDO
    {
        void        Prepare(string p_sSql);
        void        Prepare(string p_sSql, List<object> p_oParamNames);

        DataTable   Select();
        DataTable   Select(List<object> p_oParamValues);

        void        Execute();
        void        Execute(List<object> p_oParamValues);

        void        Close();
    }
    // ===============================================================================================================================
}