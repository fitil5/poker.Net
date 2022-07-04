using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Threads
{
    public class dbConnection
    {
        private NpgsqlDataAdapter myAdapter;
        private NpgsqlConnection conn;
        private DataTable _dataTable= new DataTable();

        public DataTable DataTable { get => _dataTable; set => _dataTable = value; }

        /// <constructor>
        /// Initialise Connection
        /// </constructor>
        public dbConnection()
        {
            myAdapter = new NpgsqlDataAdapter();
            conn = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        }

        /// <method>
        /// Open Database Connection if Closed or Broken
        /// </method>
        private NpgsqlConnection openConnection()
        {
            if (conn.State == ConnectionState.Closed || conn.State == ConnectionState.Broken)
            {
                conn.Open();
            }
            return conn;
        }


        public DataTable executeSelectProcedure(String _procedure, NpgsqlParameter[] npgsqlParameter)
        {
            try
            {
            NpgsqlCommand command = new NpgsqlCommand(_procedure,openConnection());
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddRange(npgsqlParameter);            
            myAdapter.SelectCommand = command;
            DataTable = new DataTable();
            myAdapter.Fill(_dataTable);
            conn.Close();
            }
            catch (NpgsqlException e)
            {
                Console.Write("Error - Connection.executeSelectQuery - Query: " + _procedure + " \nException: " + e.StackTrace.ToString());               
            }
            return _dataTable;
        }
        public Boolean executeInsertProcedure(String _procedure, NpgsqlParameter[] npgsqlParameter)
        {
            try
            {
                NpgsqlCommand command = new NpgsqlCommand(_procedure, openConnection());
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddRange(npgsqlParameter);
                command.ExecuteReader();
                conn.Close();
                return true;
            }
            catch (NpgsqlException e)
            {
               //MessageBox.Show(e.ToString());
                Console.Write("Error - Connection.executeSelectQuery - Query: " + _procedure + " \nException: " + e.StackTrace.ToString());
                return false;
            }
            
        }
    }
}
