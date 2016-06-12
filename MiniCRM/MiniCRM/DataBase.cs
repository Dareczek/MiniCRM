using System;
using System.Data.SqlClient;
using System.IO;
using System.Windows;

namespace MiniCRM
{
    public sealed class DataBase
    {
        private static DataBase _dataBase;
        private SqlConnection _sqlConnection;
        public static DataBase Instance => _dataBase ?? (_dataBase = new DataBase());
        private DataBase()
        {
            _sqlConnection = new SqlConnection(GlobalOptions.Instance.ConnectionString);
            _sqlConnection.Open();
        }
        public void Reconnect()
        {
            Disconnect();
            _sqlConnection = new SqlConnection(GlobalOptions.Instance.ConnectionString);
            _sqlConnection.Open();
        }
        private void Disconnect()
        {
            _sqlConnection.Close();
        }
        public void SendQuerry(string querry)
        {
            var sqlCommand = new SqlCommand(querry, _sqlConnection);
            try
            {
                var sqlDataReader = sqlCommand.ExecuteReader();
                sqlDataReader.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString(), "UWAGA");
            }
        }
        public SqlDataReader GetSqlDataReader(string querry)
        {
            var sqlCommand = new SqlCommand(querry, _sqlConnection);
            try
            {
                var sqlDataReader = sqlCommand.ExecuteReader();
                return sqlDataReader;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString(), "UWAGA");
                return null;
            }
        }
        #region CreateDeleteDropInsert
        public void CreateDataBase()
        {
            QuerryFromFile("CREATE.sql");
        }
        public void InsertDataBase()
        {
            QuerryFromFile("INSERT.sql");
        }
        public void DeleteDataBase()
        {
            QuerryFromFile("DELETE.sql");
        }
        public void DropDataBase()
        {
            QuerryFromFile("DROP.sql");
        }
        public void QuerryFromFile(string fileName)
        {
            string querry = null;
            try
            {
                using (var streamReader = new StreamReader(fileName))
                {
                    querry = streamReader.ReadToEnd();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Nie ma pliku sql!", "UWAGA");
            }

            try
            {
                SendQuerry(querry);
            }
            catch (SqlException exception)
            {
                MessageBox.Show(exception.ToString(), "UWAGA");
            }
        }
        #endregion
    }
}
