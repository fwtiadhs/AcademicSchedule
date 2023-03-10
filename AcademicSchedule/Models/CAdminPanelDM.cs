using System;
using System.Collections.Generic;
using System.Data;

using GLib.data.db;
using GLib.data.module;
using GLib.data.schema;

using AcademicSchedule.logic;
namespace AcademicSchedule.Models
{
    public class CAdminPanelDM : GDataModule
    {

        public List<CAdminPanel> AdminPanel = new List<CAdminPanel>();
        public CAdminPanelDM() : base()
        {


        }
        public int SelectOn(List<CAdminPanel> p_oTheoryList)
        {
            return SelectOn(p_oTheoryList, false);
        }
        public int SelectOn(List<CAdminPanel> p_oTheoryList, bool p_bIsSelectingOnlyActive)
        {


            string SELECT_SQL = String.Format(@"
                select
                      CID 
                     ,SEMESTER_NUMBER
                     ,NAME
                    
                from
                    X_LESSON
                
            ");

            int nResult = 0;

            GSqlDBTransaction oTransaction = null;
            GSqlDBQuery oSelectQuery = null;
            //GSqlFieldDict oSelectQueryParams = new GSqlFieldDict();
            try
            {
                oSelectQuery = db.SQLPrepare(SELECT_SQL);
                oTransaction = db.OpenTransaction();
                oTransaction.Include(oSelectQuery);
                oTransaction.Begin();

                DataTable oResults = oSelectQuery.SelectTable();
                nResult = oResults.Rows.Count;


                foreach (DataRow oRow in oResults.Rows)
                {
                    CAdminPanel oNewReg = new CAdminPanel();
                    oNewReg.Cid = (int)oRow["CID"];
                    oNewReg.Semester = (byte)oRow["SEMESTER_NUMBER"];
                    oNewReg.Name = (string)oRow["NAME"];
                    p_oTheoryList.Add(oNewReg);
                }

                oTransaction.Commit();
            }
            catch (Exception E)
            {
                oTransaction.Rollback();
                this.db.Log.WriteErrorLine(E.Message);
                nResult = 0;
            }

            return nResult;
        }
        public override bool Load()
        {

            AdminPanel.Clear();
            int nResult = this.SelectOn(this.AdminPanel);
            return (nResult > 0);
        }

    }

}
