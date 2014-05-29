using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

//http://csharp.net-informations.com/dataadapter/datagridview-sqlserver.htm


namespace _3._11._3
{
    public partial class Form1 : Form
    {
        private SqlConnection sqlConn;
        private SqlDataAdapter dataAdapter;
        private DataSet ds = new DataSet();

        public Form1()
        {
            InitializeComponent();
        }

        /*
        public static string BuildConnectionString(string serverName,
                                                    string dbName,
                                                    string userName,
                                                    string passWd)
        {
            return String.Format(
                @"Server={0};Database={1};User ID={2};Pwd={3};Connect Timeout=15",
                serverName, dbName, userName, passWd);
        }

        public static void GetData(string selectCommand)
        {
            /*Console.WriteLine("Polaczony z serwerem!");
            SqlCommand sqlCmd = new SqlCommand();                     
            sqlCmd.Connection = sqlConn;
            sqlCmd.CommandText = "SELECT Imię,Nazwisko,DataUrodzenia,PESEL FROM STUDENCI";



            SqlDataReader sqlReader = sqlCmd.ExecuteReader();
            while (sqlReader.Read())
            {
                Console.WriteLine("{0,-12}{1,-12}{2,-25}{3,-20}",
                                  (string)sqlReader["Imię"],
                                  (string)sqlReader["Nazwisko"],
                                  (DateTime)sqlReader["DataUrodzenia"],
                                  (Int64)sqlReader["PESEL"]);
            }

            
        }*/

        public void GetData(string sqlCommand)
        {
            sqlConn = new SqlConnection("Server=(local);Database=sqlTEST;UID=sa;PWD=pass;");

            sqlConn.Open();
            
            dataAdapter = new SqlDataAdapter(sqlCommand, sqlConn);

            dataAdapter.Fill(ds);          
        }

        private void Form1_Load(object sender, EventArgs e)
        {            
            try
            {
                GetData("SELECT Imię,Nazwisko,DataUrodzenia,PESEL FROM STUDENCI");                                                                          
                //GetData("SELECT 1,Miejscowość FROM ADRESY");
                sqlConn.Close();

                dataGridView1.DataSource = ds.Tables[0];

                // Rozszerza DataGridView, aby pasowały kolumny do załadowanej zawartości
                dataGridView1.AutoResizeColumns(
                        DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        
    }
}
