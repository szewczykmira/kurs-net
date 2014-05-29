using System;
using System.Data;
using System.Data.SqlClient;

namespace _3._11._3
{
    class Program
    {
        public static string BuildConnectionString(string serverName,
                                                    string dbName,
                                                    string userName,
                                                    string passWd)
        {
            return String.Format(
                @"Server={0};Database={1};User ID={2};Pwd={3};Connect Timeout=15",
                serverName, dbName, userName, passWd);
        }

        public static void PracaZSerwerem(SqlConnection sqlConn)
        {
            //Console.WriteLine("Polaczony z serwerem!");
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
        }

        static void Main(string[] args)
        {
            SqlConnection sqlConn = new SqlConnection();

            sqlConn.ConnectionString = BuildConnectionString("(local)", "sqlTEST", "sa", "pass");

            try
            {
                sqlConn.Open();
                PracaZSerwerem(sqlConn);
                sqlConn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
