using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GLib.data.schema;

namespace GLib.data.db
{
    public class GSqlDBQuery
    {
        // ....................................................................
        private GSqlFieldDict   __paramSchema = null;
        private GParamSchemaKind __paramSchemaKind = GParamSchemaKind.FIELDS_AND_KEY;
        // ....................................................................
        private GSqlFieldDict __params = new GSqlFieldDict();
        public GSqlFieldDict Params { get { return __params; } set {  __params = value; } }
        // ....................................................................
        private GSqlField       __lastIdentity = new GSqlField() {  Name = "#key" };
        public  GSqlField       LastIdentity { get { return __lastIdentity; } }
        // ....................................................................
        private SqlCommand      __command = null;
        //public SqlCommand Command { get { return __command; } }
        // ....................................................................
        public string SQLText { get; set; }
        // ....................................................................
        private GSqlDBTransaction __transaction = null;
        public GSqlDBTransaction Transaction 
        { 
            get
            {
                return __transaction;
            }
            
            set
            {
                this.__transaction = value;

                if (this.__command != null)
                { 
                    if (this.__transaction == null)
                        this.__command.Transaction = null;
                    else
                        this.__command.Transaction = this.__transaction.__internalTransaction;
                }
            }
        
        }
        // ....................................................................




        // -----------------------------------------------------------------------------------------------------------------------------         
        public GSqlDBQuery(SqlCommand p_oCommand)
        {
            __command = p_oCommand;
            this.Transaction = null;
        }
        // -----------------------------------------------------------------------------------------------------------------------------         
        private void copyParamValues()
        {
            if (__command.Transaction == null)
                throw new Exception("GSqlDBQuery is not connected to a transaction");

            if (__paramSchema != null)
            { 
                //TODO: Check fewer parameters than the ones provided 
                foreach (string sParamName in __paramSchema.Keys)
                { 
                    if (__paramSchema[sParamName].Value == null)
                        __command.Parameters[sParamName].Value = DBNull.Value;
                    else
                        __command.Parameters[sParamName].Value = __paramSchema[sParamName].Value;
                }
            }
        }
        // -----------------------------------------------------------------------------------------------------------------------------         



        #region // IQuery \\
        // -----------------------------------------------------------------------------------------------------------------------------         
        public GSqlDBQuery Prepare()
        {
            return Prepare(this.SQLText, null);
        }
        // -----------------------------------------------------------------------------------------------------------------------------         
        public GSqlDBQuery Prepare(string p_sSql)
        {
            return Prepare(p_sSql, null);    
        }
        // -----------------------------------------------------------------------------------------------------------------------------         
        public GSqlDBQuery Prepare(string p_sSql, GSqlFieldDict p_oParamSchema)
        {
            if (p_oParamSchema != null)
                this.Params = p_oParamSchema;
                 
            __command.CommandText = p_sSql;
            __command.Prepare();

            // Cleanup existing parameter schema
            if (__paramSchema != null)
                __paramSchema.Clear();
            __paramSchema = null;

            bool bMustAdd = true;
            string sParamName = null;

            if (Params != null)
            {
                __paramSchema = new GSqlFieldDict();
                __paramSchemaKind = Params.Kind;

                foreach (string sPropertyName in Params.Keys)
                {
                    bMustAdd = false;

                    if (sPropertyName == "#fkey")
                    {
                        bMustAdd = __paramSchemaKind == GParamSchemaKind.FOREIGN_KEY_ONLY;
                    }
                    else if (sPropertyName.StartsWith("#"))
                    {
                        bMustAdd = (__paramSchemaKind == GParamSchemaKind.FIELDS_AND_KEY) | (__paramSchemaKind == GParamSchemaKind.KEY_ONLY);
                    }
                    else
                        bMustAdd = (__paramSchemaKind == GParamSchemaKind.FIELDS_AND_KEY) | (__paramSchemaKind == GParamSchemaKind.FIELDS_ONLY);


                    if (bMustAdd)
                    {
                         sParamName = Params[sPropertyName].Name;
                        __command.Parameters.Add(new SqlParameter(Params[sPropertyName].Name, Params[sPropertyName].DBType));
                        __paramSchema[sParamName] = Params[sPropertyName];
                    }
                }
            }

            return this;
        }
        // -----------------------------------------------------------------------------------------------------------------------------         
        public DataTable SelectTable()    // polymorphism with overloaded method
        {
            DataTable oTable = new DataTable();
            // create data adapter
            using (SqlDataAdapter DataAdapter = new SqlDataAdapter(__command))
            {
                copyParamValues();
                DataAdapter.Fill(oTable);
            }

            return oTable;
        }
        // -----------------------------------------------------------------------------------------------------------------------------         
        public bool Exists()
        {
            copyParamValues();
            object oResult = __command.ExecuteScalar();
            if (oResult == null)
                return false;
            else
                return true;
        }
        // -----------------------------------------------------------------------------------------------------------------------------         
        public object SelectResult()
        {
            copyParamValues();
            return __command.ExecuteScalar();
        }
        // -----------------------------------------------------------------------------------------------------------------------------         
        public int Execute(int p_nParamValue)
        {
            __command.Parameters[0].Value = p_nParamValue;
            return __command.ExecuteNonQuery();
        }
        // -----------------------------------------------------------------------------------------------------------------------------         
        public int ExecuteInsert()
        {
            __lastIdentity.Value = -1;

            copyParamValues();
            __command.ExecuteNonQuery();
            
            if (this.Transaction != null)
                __lastIdentity.Value = this.Transaction.GetLastIdentity();

            return (int)__lastIdentity.Value;
        }
        // -----------------------------------------------------------------------------------------------------------------------------         
        public int Execute()   
        {
            copyParamValues();
            return __command.ExecuteNonQuery();
        }
        // -----------------------------------------------------------------------------------------------------------------------------         
        public void Close()
        {
            __command.Dispose();
            __command = null;
            this.Transaction = null;
        }
        // -----------------------------------------------------------------------------------------------------------------------------         
        #endregion



    }
}
