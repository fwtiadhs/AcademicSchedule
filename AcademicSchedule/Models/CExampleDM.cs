using System;
using System.Collections.Generic;
using System.Data;

using GLib.data.db;
using GLib.data.module;
using GLib.data.schema;

using AcademicSchedule.logic;

namespace AcademicSchedule.Models
{
    public class CExampleDM: GDataModule
    {

        // ....................................................................
        public List<CExample> Examples = new List<CExample>();
        // ....................................................................



        // -----------------------------------------------------------------------------------------------------------------------------         
        public CExampleDM(): base()
        {
            

        }
        // -----------------------------------------------------------------------------------------------------------------------------         
        public bool Insert(string p_sCode, string p_sDescription)
        {
            CExample oExample = new CExample();
            oExample.Code = p_sCode;
            oExample.Description = p_sDescription;

            oExample.EntryTime= DateTime.Now;
            oExample.Amount = 9.99;
            oExample.ValueInteger = 1000;
            oExample.IsActive = true;

            return Insert(oExample);
        }
        // -----------------------------------------------------------------------------------------------------------------------------         
        public bool Insert(CExample p_oExample) // Example of polymorphism with adaptation of parameters in overloaded methods
        {
            string INSERT_SQL = @"
                INSERT INTO X_EXAMPLE 
                (
                     CODE
                    ,DESCR
                    ,ENTRY_TIME
                    ,AMOUNT
                    ,VALUE_INT
                    ,IS_ACTIVE
                    )
                    VALUES
                    (
                     @CODE
                    ,@DESCR
                    ,@ENTRY_TIME
                    ,@AMOUNT
                    ,@VALUE_INT
                    ,@IS_ACTIVE
                    )";

            bool bResult = true;

            GSqlDBTransaction oTransaction = null;
            GSqlDBQuery oInsertQuery = null;

            GSqlFieldDict oInsertQueryParams = new GSqlFieldDict();
            oInsertQueryParams.Add("Code", "CODE", SqlDbType.NVarChar);
            oInsertQueryParams.Add("Description", "DESCR", SqlDbType.NVarChar);
            oInsertQueryParams.Add("EntryTime", "ENTRY_TIME", SqlDbType.DateTime);
            oInsertQueryParams.Add("Amount", "AMOUNT", SqlDbType.Float);
            oInsertQueryParams.Add("ValueInteger", "VALUE_INT", SqlDbType.Int);
            oInsertQueryParams.Add("IsActive", "IS_ACTIVE", SqlDbType.TinyInt);

            try
            {
                oInsertQuery = db.SQLPrepare(INSERT_SQL, oInsertQueryParams);
                oTransaction = db.OpenTransaction();
                oTransaction.Include(oInsertQuery);
                oTransaction.Begin();
                oInsertQueryParams["Code"].Value = p_oExample.Code;
                oInsertQueryParams["Description"].Value = p_oExample.Description;;
                oInsertQueryParams["EntryTime"].Value = p_oExample.EntryTime;
                oInsertQueryParams["Amount"].Value = p_oExample.Amount;
                oInsertQueryParams["ValueInteger"].Value = p_oExample.ValueInteger;
                oInsertQueryParams["IsActive"].Value = p_oExample.IsActive?1:0;

                oInsertQuery.Execute();
                oTransaction.Commit();
            }
            catch (Exception E)
            {
                oTransaction.Rollback();
                this.db.Log.WriteErrorLine(E.Message);
                bResult = false;
            }



            return bResult;
        }
        // ---------------------------------------------------------------------------------------------------------------------------
        public int SelectTo(List<CExample> p_oDestList)   // Example of polymorphism with default values in overloaded methods
        {
            return SelectTo(p_oDestList, false);
        }
        // ---------------------------------------------------------------------------------------------------------------------------
        public int SelectTo(List<CExample> p_oDestList, bool p_bIsSelectingOnlyActive)
        {

            string sWhere = String.Empty;
            if (p_bIsSelectingOnlyActive)
                sWhere = "where (IS_ACTIVE = 1)";

            string SELECT_SQL = String.Format(@"
                select 
                     CODE
                    ,DESCR
                    ,ENTRY_TIME
                    ,AMOUNT
                    ,VALUE_INT
                    ,IS_ACTIVE
                from
                    X_EXAMPLE 
                {0}
                order by 
                    CODE asc, ENTRY_TIME desc
            ", sWhere);

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
                    CExample oNewExample = new CExample();
                    oNewExample.Code = (string)oRow["CODE"];
                    oNewExample.Description = (string)oRow["DESCR"];
                    oNewExample.EntryTime = (DateTime)oRow["ENTRY_TIME"];
                    oNewExample.Amount = (double)oRow["AMOUNT"];
                    oNewExample.ValueInteger = (int)oRow["VALUE_INT"];
                    oNewExample.IsActive = ((byte)oRow["IS_ACTIVE"]) == 1;
                    p_oDestList.Add(oNewExample);
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
        // -----------------------------------------------------------------------------------------------------------------------------
        public override bool Load()
        {
            // [PANTELIS]: We write the DB operations inside this module object, that acts as the Model in MVC. 
            // Thus we decouple the Controller for all DB operations, allowing for standalone use of the Model.

            Examples.Clear();
            int nResult = this.SelectTo(this.Examples);
            return (nResult > 0);
        }
        // ---------------------------------------------------------------------------------------------------------------------------

    }
}
