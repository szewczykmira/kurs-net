using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;


// Rozwiazanie problemu z Provider'em na systemach 64 bitowych.
//http://www.connectionstrings.com/excel-2007
//http://social.msdn.microsoft.com/Forums/en-US/adodotnetdataproviders/thread/db9556f4-b881-40a9-91fd-54da26d58a4c

//***********************//
//http://codehill.com/2009/01/reading-excel-2003-and-2007-files-using-oledb/
//http://social.msdn.microsoft.com/Forums/en-US/adodotnetdataproviders/thread/f8bfc7a2-91ef-4558-8ac8-910b2fdfeee8
//http://kbalertz.com/815545/unhandled-exception-occurs-after-rename-columns-DataSet-object.aspx
//http://codehill.com/2009/01/reading-excel-2003-and-2007-files-using-oledb/
//http://www.codeproject.com/Articles/37055/Working-with-MS-Excel-xls-xlsx-Using-MDAC-and-Oled
//http://www.codeproject.com/Articles/8500/Reading-and-Writing-Excel-using-OLEDB
//http://csharp.net-informations.com/data-providers/csharp-oledbdatareader.htm
/* ListView
 * http://java2s.com/Tutorial/CSharp/0460__GUI-Windows-Forms/FilldatafromDatabasetoListView.htm
 * http://www.codeproject.com/Articles/20733/How-to-Populate-a-DataGridView-Control-using-OleDb
 */

/* przyklad z dataAdapterami
    OleDbDataAdapter cmd = new OleDbDataAdapter(
        "select * from [" + "Arkusz1" + "$]", conn);
 
    conn.Open();
    DataSet dataSet = new DataSet();
    cmd.Fill(dataSet);
    conn.Close();
            
    DataTable dataTable = dataSet.Tables[0];

    for (int i = 0; i < dataTable.Rows.Count; i++)
    {
        for (int j = 0; j < dataTable.Columns.Count; j++)
            Console.Write(dataTable.Rows[i][dataTable.Columns[j].ColumnName] + " ");
        Console.WriteLine();
    }
 */

namespace _3._11._1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
       

        private void Form1_Load(object sender, EventArgs e)
        {
            string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Dane.xlsx;Extended Properties=\"Excel 12.0 Xml;HDR=YES\"";

            OleDbConnection conn = new OleDbConnection(connectionString);

            OleDbCommand cmd = new OleDbCommand("select * from [" + "Arkusz1" + "$]", conn);
            

            try
            {
                conn.Open();
                OleDbDataReader exelData = cmd.ExecuteReader();


                for (int i = 0; i <= exelData.FieldCount - 1; i++)
                    listView1.Columns.Add(exelData.GetName(i).ToString(), 100, HorizontalAlignment.Left);                                  
                                    
                while (exelData.Read())
                {
                    ListViewItem lvItem = new ListViewItem(exelData[0].ToString());
                    for (int i = 1; i <= exelData.FieldCount - 1; i++)
                        lvItem.SubItems.Add(exelData[i].ToString());

                    listView1.Items.Add(lvItem);                                        
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Nie można otworzyć pliku excela\n");
            }            
        }
    }
}
