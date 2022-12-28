using GLib.common;
using GLib.data.schema;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace GLib.data.db
{
    public class GSqlDB
    {

        // ....................................................................
        private GSqlDBTransaction __activeTransaction;
        // ....................................................................
        private ILog __log = new GDebugLog();
        public ILog Log { get { return __log; } }
        // ....................................................................
        private GSqlDBCredentials __credentials = null;
        public GSqlDBCredentials Credentials { get { return __credentials; } }
        // ....................................................................
        private SqlConnection __connection;
        public SqlConnection Connection { get { return __connection; } }
        // ....................................................................
        private bool __isConnected = false;
        public bool IsConnected { get { return __isConnected; } }
        // ....................................................................



        // -----------------------------------------------------------------------------------------------------------------------------
        public GSqlDB(GSqlDBCredentials p_oDBCredentials)
        {
            //Renders the connection string from the credential objects, for cross-database support
            __credentials = p_oDBCredentials;
        }
        // -----------------------------------------------------------------------------------------------------------------------------
        public void Connect()
        {
            if (__connection == null)
                __connection = new SqlConnection();

            if (__connection.State != ConnectionState.Open)
            {
                try
                {
                    //TcpClient tcp = new System.Net.Sockets.TcpClient(__credentials.DBHost, 1433);
                    TcpClient tcp = new System.Net.Sockets.TcpClient(__credentials.DBHost, __credentials.DBPort);
                    if (tcp.Connected)
                        __log.WriteLine(String.Format("MSSQL Server running on host {0} listening to port {1}.", __credentials.DBHost, __credentials.DBPort));
                    else
                        __log.WriteLine(String.Format("MSSQL Server is not responding at {0}:{1}.", __credentials.DBHost, __credentials.DBPort));
                    tcp.Close();

                    __connection.ConnectionString = __credentials.GetConnectionString();
                    __connection.Open();

                    __isConnected = true;
                }
                catch (Exception ex)
                {
                    __log.WriteErrorLine(String.Format("Error connecting to MSSQL Server at {0}:{1} - {1}.", __credentials.DBHost, __credentials.DBPort, ex.Message));
                }
            }

        }
        // -----------------------------------------------------------------------------------------------------------------------------         
        public void Disconnect()
        {
            if (__isConnected && (__connection.State == ConnectionState.Open))
            {
                if (__activeTransaction != null)
                    CloseTransaction(__activeTransaction);

                __connection.Close();
                __connection.Dispose();
                __connection = null;
                __isConnected = false;
            }
        }
        // -----------------------------------------------------------------------------------------------------------------------------         
        public GSqlDBQuery SQL(string p_sSQL)
        {
            SqlCommand oNewCommand = this.__connection.CreateCommand();
            GSqlDBQuery oQuery = new GSqlDBQuery(oNewCommand);
            oQuery.SQLText = p_sSQL;

            return oQuery;            
        }
        // -----------------------------------------------------------------------------------------------------------------------------         
        public GSqlDBQuery SQLPrepare(string p_sSQL, GSqlFieldDict p_oParams = null) // Factory method pattern
        {
            GSqlDBQuery oQuery = SQL(p_sSQL);
            oQuery.Prepare(p_sSQL, p_oParams);
            
            return oQuery;
        }
        // -----------------------------------------------------------------------------------------------------------------------------         
        public static ConcurrentQueue<int> queue = new ConcurrentQueue<int>();
        public const int QUEUE_SLEEP_TIME = 100;

        // -----------------------------------------------------------------------------------------------------------------------------         

        public GSqlDBTransaction OpenTransaction()
        {
            if (__isConnected)
            {
                // Safeguarding the concurrent calls to the creation of a new transactions
                // This is the problem described in https://stackoverflow.com/questions/19559715/when-does-sqlconnection-does-not-support-parallel-transactions-happen

                GSqlDBTransaction oNewTransaction = new GSqlDBTransaction(this, this.__connection);
                queue.Enqueue(oNewTransaction.UID);

                int sTopOfQueue;
                //int nTotalWait = 0;
                bool bContinue = true;
                while(bContinue)
                {
                    if (queue.TryPeek(out sTopOfQueue))
                        bContinue = (sTopOfQueue != oNewTransaction.UID);
                }

                __activeTransaction = oNewTransaction;
            }

            return __activeTransaction;
        }
        // -----------------------------------------------------------------------------------------------------------------------------         
        public void CloseTransaction(GSqlDBTransaction p_oTransaction)
        {
            if (__activeTransaction == p_oTransaction)
            { 
                __activeTransaction = null;

                int sTopOfQueue = -1;
                bool bStop = false;
                while(!bStop)
                { 
                    bStop = queue.TryDequeue(out sTopOfQueue);
                }
                if (sTopOfQueue != p_oTransaction.UID)
                    throw new Exception("Transaction synchronization failed!");
            }
        }
        // -----------------------------------------------------------------------------------------------------------------------------         
        public GSqlDBTransaction BeginTransaction()
        {
            GSqlDBTransaction oResult = this.OpenTransaction();
            oResult.Begin();
            return oResult;
        }
        // -----------------------------------------------------------------------------------------------------------------------------         

    }
    // =============================================================================================================================
}
