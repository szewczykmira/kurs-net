using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Zadanie_3_5_1
{
    class Program
    {
        [DllImport("advapi32.dll", EntryPoint="GetUserName")]
        static extern bool GetUserName(byte[] lpBuffer, Int32[] nSize);

        [DllImport("user32.dll", EntryPoint = "MessageBox")]
        static extern int MsgBox(int hWnd, String text, String caption, uint type);

        static void Main(string[] args)
        { 
            byte[] str=new byte[256];
            Int32[] len = new Int32[1];
            len[0]=256;
            GetUserName(str,len);
            MsgBox(0, System.Text.Encoding.ASCII.GetString(str), " ", 0);
            Console.ReadLine();
        }
    }
}
