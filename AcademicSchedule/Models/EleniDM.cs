using System;
using System.Collections.Generic;
using System.Data;

using GLib.data.db;
using GLib.data.module;
using GLib.data.schema;

using AcademicSchedule.logic;

namespace AcademicSchedule.Models
{
    public class EleniDM : GDataModule
    {
        public List<CEleni> Eleni = new List<CEleni>();   

        public EleniDM() : base()
        {

        }
        public int SelectTo(List<CEleni> p_oLessonList)
        {
            return SelectTo(p_oLessonList, false);
        }

        public int SelectTo(List<CEleni> p_oLessonList, bool p_bIsSelectingOnlyActive)
        {

            string SELECT_SQL = String.Format(@"
                select 
                     CODE
                    ,LESSON
                from
                    X_ELENI 
                
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
                    CEleni oNewEleni = new CEleni();
                    oNewEleni.Code = (string)oRow["CODE"];
                    oNewEleni.Lesson = (string)oRow["LESSON"];
                   
                    p_oLessonList.Add(oNewEleni);
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
            Eleni.Clear();
            int nResult = this.SelectTo(this.Eleni);
            return (nResult > 0);
        }
    }
}
