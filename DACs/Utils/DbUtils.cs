using System;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace DACs.Utils
{
    public static class DbUtils
    {
        private const string dataSrc = "anh\\SQLEXPRESS"; // thay dong nay
        private static string GetConnectionString(string dataSrc)
        {
            return $"Data Source={dataSrc};Initial Catalog=YODY_LTAT_DB;Integrated Security=True";
        }
        private static string connectionString = GetConnectionString(dataSrc);
        private static SqlConnection sqlConnection = new SqlConnection(connectionString);
        private static SqlCommand sqlCommand = null;
        private static SqlDataAdapter dataAdapter = null;
        private static DataTable dataTable = null;
        private static void initOperators()
        {
            sqlCommand = new SqlCommand();
            dataAdapter = new SqlDataAdapter();
            dataTable = new DataTable();
        }
        private static void openConnection()
        {
            if (sqlConnection != null && ConnectionState.Closed == sqlConnection.State)
                sqlConnection.Open();
        }

        private static void closeConnection()
        {
            if (sqlCommand != null)
                sqlCommand.Dispose();
            if (dataAdapter != null)
                dataAdapter.Dispose();
            if (sqlConnection != null && ConnectionState.Open == sqlConnection.State)
                sqlConnection.Close();
        }
        public static DataTable executeSelectQuery(string query, SqlParameter[] parameters)  
        {
            initOperators();
            try
            {
                openConnection();
                sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandText = query;
                if (parameters != null && parameters.Length >= 1)
                    sqlCommand.Parameters.AddRange(parameters);
                dataTable.Clear();
                dataAdapter.SelectCommand = sqlCommand;
                dataAdapter.Fill(dataTable);
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                closeConnection();
            }
            return dataTable;
        }
        public static int executeNonDataQuery(string query, SqlParameter[] parameters)
        {
            int rows = 0;
            sqlCommand = new SqlCommand();

            try
            {
                openConnection();
                sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandText = query;
                if (parameters != null && parameters.Length >= 1)
                    sqlCommand.Parameters.AddRange(parameters);
                rows = sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                closeConnection();
            }
            return rows;
        }
    }
}
