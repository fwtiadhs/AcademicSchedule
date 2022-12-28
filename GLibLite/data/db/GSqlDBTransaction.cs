using GLib.data.schema;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;


namespace GLib.data.db
{
    // ===============================================================================================================================
    public class GSqlDBTransaction
    {
        private static int __nextUID = 0;
        public static int NextUID
        {
            get
            {
                if (__nextUID == int.MaxValue)
                    __nextUID = 1;
                else
                    __nextUID++;
                return __nextUID;
            }
        }

        private SqlConnection      __parentConnection = null;
        internal SqlTransaction     __internalTransaction = null;
        private SqlCommand         __lastIdentityCommand = null;
        private List<GSqlDBQuery>  __ownedQueries = new List<GSqlDBQuery>();
        private List<GSqlDBQuery>  __externalQueries = new List<GSqlDBQuery>();
        private GSqlDB             __db = null;
        public  int                UID;

        // -----------------------------------------------------------------------------------------------------------------------------         
        public GSqlDBTransaction(GSqlDB p_oDB, SqlConnection p_oParentConnection)
        {
            this.__db               = p_oDB;
            this.__parentConnection = p_oParentConnection;  
            this.UID                = GSqlDBTransaction.NextUID;
        }
        // -----------------------------------------------------------------------------------------------------------------------------
        public int GetLastIdentity()
        {
            int nResult = -1;
            object oIdentity;

            if (__lastIdentityCommand == null)
                __lastIdentityCommand = new SqlCommand("SELECT @@IDENTITY AS LAST_ID", __parentConnection);

            __lastIdentityCommand.Transaction = __internalTransaction;
            oIdentity = __lastIdentityCommand.ExecuteScalar();
            if (oIdentity != null)
                if (oIdentity != DBNull.Value)
                    nResult = Convert.ToInt32(oIdentity);

            return nResult;
        }
        // -----------------------------------------------------------------------------------------------------------------------------
        public long GetLastIdentityLong()
        {
            long nResult = -1;
            object oIdentity;

            if (__lastIdentityCommand == null)
                __lastIdentityCommand = new SqlCommand("SELECT @@IDENTITY AS LAST_ID", __parentConnection);

            __lastIdentityCommand.Transaction = __internalTransaction;
            oIdentity = __lastIdentityCommand.ExecuteScalar();
            if (oIdentity != null)
                nResult = Convert.ToInt64(oIdentity);

            return nResult;
        }
        // -----------------------------------------------------------------------------------------------------------------------------         
        public void Begin()
        {
            if (__internalTransaction == null)
            { 
                __internalTransaction = __parentConnection.BeginTransaction();
                foreach (GSqlDBQuery oQuery in __externalQueries)
                    oQuery.Transaction = this;
                    //oQuery.Command.Transaction = __internalTransaction;
            }
            else
                throw new Exception("Nested transactions are not allowed!");
        }
        // -----------------------------------------------------------------------------------------------------------------------------         
        public void Commit()
        {
            if (__internalTransaction != null)
            {
                __internalTransaction.Commit();
                Close();
            }
        }
        // -----------------------------------------------------------------------------------------------------------------------------         
        public void Rollback()
        {
            if (__internalTransaction != null)
            {
                __internalTransaction.Rollback();
                Close();
            }

        }
        // -----------------------------------------------------------------------------------------------------------------------------         
        public void Close()
        {
            if (__internalTransaction != null)
            { 
                // Dispose the unmanaged objects in the transaction 
                __internalTransaction.Dispose();
                __internalTransaction = null;
            }

            // Close each opened (prepared) query and empty the list. Internally the unmanaged command object is disposed
            foreach(GSqlDBQuery oQuery in __ownedQueries)
                oQuery.Close();
            __ownedQueries.Clear();

            // Remove transaction from external queries
            foreach (GSqlDBQuery oQuery in __externalQueries)
            { 
                //oQuery.Command.Transaction = null;
                oQuery.Transaction = null;
            }
            __externalQueries.Clear();

            this.__db.CloseTransaction(this);
        }
        // -----------------------------------------------------------------------------------------------------------------------------         
        public void Include(GSqlDBQuery p_oQuery)
        { 
            this.__externalQueries.Add(p_oQuery);
            p_oQuery.Transaction = this;
            //p_oQuery.Command.Transaction = this.__internalTransaction;
        }
        // -----------------------------------------------------------------------------------------------------------------------------         
        // This is an alias method for CreateQuery. Such methods helps us write more elegant inline syntax
        public GSqlDBQuery SQLPrepare(string p_sSQL)
        {
            return SQLPrepare(p_sSQL, null);
        }
        // -----------------------------------------------------------------------------------------------------------------------------         
        public GSqlDBQuery SQLPrepare(string p_sSQL, GSqlFieldDict p_oParams = null) // Factory method pattern
        {
            SqlCommand oNewCommand  = this.__parentConnection.CreateCommand();
            oNewCommand.Transaction = this.__internalTransaction;

            

            GSqlDBQuery oQuery = new GSqlDBQuery(oNewCommand);

            oQuery.Prepare(p_sSQL, p_oParams);
            __ownedQueries.Add(oQuery);
            oQuery.Transaction = this;

            return oQuery;
        }
        // -----------------------------------------------------------------------------------------------------------------------------         

    }
    // ===============================================================================================================================

}