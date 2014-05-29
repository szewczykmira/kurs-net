using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data.SqlClient;

//http://bloggingabout.net/blogs/dennis/archive/2008/02/29/getting-data-from-excel-the-fast-way-using-linq.aspx
//http://www.hookedonlinq.com/LINQtoDatasets.ashx

namespace _3._11._6
{
    class Program
    {
        static void Main(string[] args)
        {


            string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Dane2.xlsx;Extended Properties=\"Excel 12.0 Xml;HDR=YES\"";
            OleDbDataAdapter dataAdapter;
            DataSet ds = new DataSet();
            
            
            try
            {                                        

                dataAdapter = new OleDbDataAdapter("select * from [" + "Arkusz1" + "$]", connectionString);

                dataAdapter.Fill(ds);

                DataTable table = ds.Tables[0];

                var query = from p in table.AsEnumerable()
                            select new
                            {
                                Pesel = p.Field<double>("PESEL"),

                                Konto = p.Field<double>("NumerKonta")
                            };

                Console.WriteLine("PESEL\t\t\tNumerKonta\n");
                foreach (var row in query)
                    Console.WriteLine(row.Pesel + "\t\t" + row.Konto);

                Console.WriteLine("\n\n");    
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }            

        }
    }
}
