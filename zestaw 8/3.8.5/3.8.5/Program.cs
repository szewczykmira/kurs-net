using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management;
using System.Globalization;
using Microsoft.Win32;

//http://msdn.microsoft.com/en-us/library/windows/desktop/aa394373(v=vs.85).aspx
//http://msdn.microsoft.com/en-us/library/windows/desktop/aa394080(v=vs.85).aspx

namespace _3._8._5
{
    class Program
    {
        static void Main(string[] args)
        {            
            ManagementObjectSearcher s1 = new ManagementObjectSearcher("select * from Win32_Processor");            
            ManagementObjectSearcher s2 = new ManagementObjectSearcher("select * from Win32_OperatingSystem");
            ManagementObjectSearcher s3 = new ManagementObjectSearcher("select * from Win32_ComputerSystem");
            ManagementObjectSearcher s4 = new ManagementObjectSearcher("select * from Win32_DesktopMonitor");
            ManagementObjectSearcher s5 = new ManagementObjectSearcher("select * from Win32_DisplayConfiguration");
            ManagementObjectSearcher s6 = new ManagementObjectSearcher("select * from Win32_Printer");

            foreach (ManagementObject mo in s1.Get())
            {
                Console.WriteLine("--- Model processora: " + mo["name"]);
                Console.WriteLine("--- Częstotliwość taktowania: " + mo["CurrentClockSpeed"] + " Mhz");
            }                     

            foreach (ManagementObject mo in s2.Get())            
                Console.WriteLine("--- Wolna pamięć operacyjna: {0} KB", mo["FreePhysicalMemory"]);            

            foreach (ManagementObject mo in s3.Get())
                Console.WriteLine("--- Całkowita pamięc operacyjna: {0} KB", mo["TotalPhysicalMemory"]);

            foreach (ManagementObject mo in s2.Get())
            {
                Console.WriteLine("--- Wersja systemu operacyjnego: " + mo["Version"]);
                Console.WriteLine("--- Wersja uaktualnienia: " + mo["ServicePackMajorVersion"] + "." + mo["ServicePackMinorVersion"]);
                Console.WriteLine("--- Wersja językowa: " + mo["OSLanguage"]);
            }

            Console.WriteLine("--- Wersja NetFramework nadzorująca wykonanie programu: " + Environment.Version);

            foreach (ManagementObject mo in s3.Get())            
                Console.WriteLine("--- Nazwa sieciowa komputera i zalogowanego użytkownika: " + mo["UserName"]);

            foreach (ManagementObject mo in s4.Get())
                Console.WriteLine("--- Rozdzielczość: " + mo["ScreenWidth"] + "x" + mo["ScreenHeight"]);

            foreach (ManagementObject mo in s5.Get())            
                Console.WriteLine("--- Głębia kolorów: " + mo["BitsPerPel"] + " bpp");

            Console.WriteLine("--- Podłączone drukarki: ");
            foreach (ManagementObject mo in s6.Get())            
                Console.WriteLine("    * " + mo["Name"]);


            RegistryKey klucz1 = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Internet Explorer");
            if (klucz1 != null)
                Console.WriteLine("--- Wersja Internet Explorera: " + klucz1.GetValue("Version"));            

            RegistryKey klucz2 = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Office");

            if (klucz2 != null)                
            {
                Console.WriteLine("--- Wersje Microsoft Word:");
                foreach (string v in klucz2.GetSubKeyNames())
                {
                    double liczba = 0;
                    if (double.TryParse(v, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out liczba))                    
                        Console.WriteLine("    * " + v);                    
                }
            }
            Console.ReadLine();
        }
    }

}
