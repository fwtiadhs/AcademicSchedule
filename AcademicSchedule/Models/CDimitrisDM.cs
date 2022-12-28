using System;
using System.Collections.Generic;
using System.Data;

using GLib.data.db;
using GLib.data.module;
using GLib.data.schema;

using AcademicSchedule.logic;


namespace AcademicSchedule.Models
{
    public class CDimitrisDM : GDataModule
    {

        public List<CDimitris> Dimitriss = new List<CDimitris>();


        public CDimitrisDM() : base()
        {


        }
     
        public int SelectFrom(List<CDimitris> p_oMovieList)   
        {
            return SelectFrom(p_oMovieList, false);
        }
        public int SelectFrom(List<CDimitris> p_oMovieList , bool p_bIsSelectingOnlyActive)
        {

         
            string SELECT_SQL = String.Format(@"
                select
                      ID
                     ,CODE
                    ,MOVIE
                from
                    X_DIMITRIS 
                
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
                    CDimitris oNewDimitris = new CDimitris();
                    oNewDimitris.Id = (int)oRow["ID"];
                    oNewDimitris.Code = (string)oRow["CODE"];
                    oNewDimitris.Movie = (string)oRow["MOVIE"];
                    p_oMovieList.Add(oNewDimitris);
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

            Dimitriss.Clear();
            int nResult = this.SelectFrom(this.Dimitriss);
            return (nResult > 0);
        }
    }

}
