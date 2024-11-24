using Microsoft.Data.SqlClient;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
namespace WpfApp1
{
    public class SQLIntraction
    {
        string connectionString=string.Empty;
        string DB = ConfigurationHelper.GetAppSetting("DB");
        //MS SQL Connection
        private SqlConnection connection;
        public SQLIntraction() {

            SQLConnection();
            if (DB == "MSSQL")
            {
                insertData();
                UpdateData();
                GetData();
            }
        }

        public void SQLConnection()
        {

            //MS SQL Connection
            if (DB == "MSSQL")
            {
                connectionString = ConfigurationHelper.GetConnectionString("MSSQLDBConnection");
                connection = new SqlConnection(connectionString);
                try
                {
                    connection.Open();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"MS SQL Connection error: {ex.Message}");
                }
            }
            else
            {
                //MariaDB Connection
                connectionString = ConfigurationHelper.GetConnectionString("MariaDBLocalConnection") ;
                using (var connection = new MySqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"MariaDB Connection error: {ex.Message}");
                    }
                }
            }
        }
        public void insertData()
        {
            SqlCommand insertCommand = new SqlCommand();
            insertCommand.Connection = connection;
            insertCommand.CommandType=CommandType.Text;
            insertCommand.CommandText = "Insert into student values (1,'Gabriel Gina','Westmoreland road')";
            insertCommand.ExecuteNonQuery();
        }
        public void UpdateData()
        {
            SqlCommand Command = new SqlCommand("update Student set Name='Anna Richard' where StudentId=21", connection);
            Command.CommandType = CommandType.Text;
            int Rowcount= Command.ExecuteNonQuery();
            if(Rowcount > 0 ) Console.WriteLine("Data saved");

            SqlCommand Command1 = new SqlCommand("Select * from student", connection);
            Command.CommandType = CommandType.Text;

            SqlDataReader reader= Command1.ExecuteReader();
            if (reader.HasRows)
            {
                /*
                 *  Reader can hold only time. If it is readed then we cannot
                    get after any data from that reader.
                    Here, if While loop reads data then "datatable" can't get data.
                    which is drawback of reader

                    Also, need to close the reader manually.
                */
                //while (reader.Read())
                //{
                //    Console.WriteLine(reader.GetString(2));
                //}

                DataTable dataTable = new DataTable();
                dataTable.Load(reader);
                string names = "";
                foreach (DataRow row in dataTable.Rows)
                {
                    names += row[2].ToString()+",";
                }
                names.TrimEnd(',');

                reader.Close();
            }
        }
        public void GetData()
        {
            using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("Select * from student", connection))
            {
                DataSet dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet);
                string names = "";
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    names += row[2].ToString() + ",";
                }
                names.TrimEnd(',');
            }
        }
    }
}
