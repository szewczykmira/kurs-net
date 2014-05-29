using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data.SqlClient;

//http://weblogs.asp.net/scottgu/archive/2007/05/19/using-linq-to-sql-part-1.aspx
//http://weblogs.asp.net/rajbk/archive/2010/03/12/joins-in-linq-to-sql.aspx
//http://www.totaldotnet.com/Article/ShowArticle73_LinQ2DataTable.aspx
//http://www.hookedonlinq.com/JoinOperator.ashx


// Łączenie dwóch tabel, jednej z sql'a, a drugiej z excela. Łączymy na podstawie pola PESEL.

namespace _3._11._7
{
    class Program
    {
        static void Main(string[] args)
        {
            // obsluga excela
            string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Dane2.xlsx;Extended Properties=\"Excel 12.0 Xml;HDR=YES\"";
            OleDbDataAdapter dataAdapter1;
            DataSet ds1 = new DataSet();

            // obsluga sql'a
            SqlConnection sqlConn;
            SqlDataAdapter dataAdapter2;
            DataSet ds2 = new DataSet();

            try
            {

                dataAdapter1 = new OleDbDataAdapter("select * from [" + "Arkusz1" + "$]", connectionString);
                dataAdapter1.Fill(ds1);
                DataTable table1 = ds1.Tables[0];

                sqlConn = new SqlConnection("Server=(local);Database=sqlTEST;UID=sa;PWD=pass;");
                sqlConn.Open();
                dataAdapter2 = new SqlDataAdapter("SELECT Imię,Nazwisko,DataUrodzenia,PESEL FROM STUDENCI", sqlConn);
                dataAdapter2.Fill(ds2);
                DataTable table2 = ds2.Tables[0];                

                
                var query =  from t2 in table2.AsEnumerable()
                             join t1 in table1.AsEnumerable() on Convert.ToDouble(t2.Field<Int64>("PESEL")) equals t1.Field<double>("PESEL")                                                
                             select new 
                             { 
                                 Imie = t2.Field<string>("Imię"),
                                 Nazwisko = t2.Field<string>("Nazwisko"),
                                 DataUrodzenia = t2.Field<DateTime>("DataUrodzenia"),
                                 PESEL = t2.Field<Int64>("PESEL"),
                                 NumerKonta = t1.Field<double>("NumerKonta")
                             };

                foreach (var r in query)
                {
                    Console.WriteLine("{0} {1} {2} {3} {4}", 
                        r.Imie, r.Nazwisko, r.DataUrodzenia, r.PESEL, r.NumerKonta);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }            

        }
    }
}
