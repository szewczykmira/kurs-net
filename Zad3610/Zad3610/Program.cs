using System;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;

namespace Zad3610
{
    class Program
    {
        static void wypisz(CultureInfo culture)
        {
            Console.WriteLine(culture.Name);
            Console.WriteLine("Months:");
            for (int i = 1; i <= 12; i++)
            {
                Console.WriteLine(culture.DateTimeFormat.GetAbbreviatedMonthName(i) + " " + culture.DateTimeFormat.GetMonthName(i));
            }
            Console.WriteLine("Days");
            Console.WriteLine(culture.DateTimeFormat.GetAbbreviatedDayName(DayOfWeek.Monday) + " " + culture.DateTimeFormat.GetDayName(DayOfWeek.Monday));
            Console.WriteLine(culture.DateTimeFormat.GetAbbreviatedDayName(DayOfWeek.Tuesday) + " " + culture.DateTimeFormat.GetDayName(DayOfWeek.Tuesday));
            Console.WriteLine(culture.DateTimeFormat.GetAbbreviatedDayName(DayOfWeek.Wednesday) + " " + culture.DateTimeFormat.GetDayName(DayOfWeek.Wednesday));
            Console.WriteLine(culture.DateTimeFormat.GetAbbreviatedDayName(DayOfWeek.Thursday) + " " + culture.DateTimeFormat.GetDayName(DayOfWeek.Thursday));
            Console.WriteLine(culture.DateTimeFormat.GetAbbreviatedDayName(DayOfWeek.Friday) + " " + culture.DateTimeFormat.GetDayName(DayOfWeek.Friday));
            Console.WriteLine(culture.DateTimeFormat.GetAbbreviatedDayName(DayOfWeek.Saturday) + " " + culture.DateTimeFormat.GetDayName(DayOfWeek.Saturday));
            Console.WriteLine(culture.DateTimeFormat.GetAbbreviatedDayName(DayOfWeek.Sunday) + " " + culture.DateTimeFormat.GetDayName(DayOfWeek.Sunday));
            DateTime now = DateTime.Now;
            Console.WriteLine("Today is " + now.ToString("d",culture));
        }
        static void Main(string[] args)
        {
            CultureInfo angielski = new CultureInfo("en-Gb", false);
            CultureInfo niemiecki = new CultureInfo("de-De",false);
            CultureInfo francuski = new CultureInfo("fr-Fr",false);
            CultureInfo rosyjski = new CultureInfo("ru-Ru", false) ;
            CultureInfo arabski = new CultureInfo("ar-Sa",false);
            CultureInfo czeski = new CultureInfo("cs-CZ",false);
            CultureInfo polski = new CultureInfo("pl-PL",false);
            wypisz(angielski);
            wypisz(niemiecki);
            wypisz(francuski);
            wypisz(rosyjski);
            wypisz(arabski);
            wypisz(czeski);
            wypisz(polski);
            Console.ReadLine();
        }
    }
}
