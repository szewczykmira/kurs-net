using System;
using System.Threading;
using System.Collections.Concurrent;


namespace SleepingBarber
{
    class Program
    {
        internal static AutoResetEvent customerEvent = new AutoResetEvent(false);

        internal static ConcurrentQueue<Customer> queue = new ConcurrentQueue<Customer>();

        static void Main(string[] args)
        {
            Random rand = new Random();

            // nie wpływa na priorytet
            new Thread(Barber.CutHair) { IsBackground = true, Name = "Fryzjer" }.Start();

            Thread.Sleep(100);

            Thread.CurrentThread.Name = "Main";
            // tworzy jakichś klientów
            for (int i = 0; i < 24; i++)
            {
                // temp jest używany do łapania różnych problemów
                int temp = i;
                Thread.Sleep(rand.Next(600, 2000));
                Customer c = new Customer() { Name = "Klient " + temp };
                queue.Enqueue(c);

                if (queue.Count == 1)
                {
                    Customer.WakeUpBarber();
                }
            }

            Console.ReadKey();
        }
    }

    class Customer
    {
        public string Name { get; set; }

        internal static void WakeUpBarber()
        {
            Program.customerEvent.Set();
        }
    }

    class Barber
    {
        internal static void CutHair()
        {
            while (!Program.queue.IsEmpty)
            {
                Customer c;

                // Czas obcinania włosów to 1s
                Thread.Sleep(1000);

                // po zajęciu się klientem fryzjer wyrzuca go z kolejki
                if (Program.queue.TryDequeue(out c))
                {
                    Console.WriteLine("Zajmuje się fryzurą {0}", c.Name);
                }
                else
                {
                    // to się nie zdarzy jeżeli jest tylko jeden fryzjer
                    Console.WriteLine("Klient ciągle siedzi.");
                }
            }

            Console.WriteLine("Idzie spać... Zzzz...");
            GoToSleep();
        }

        private static void GoToSleep()
        {

                Program.customerEvent.WaitOne();
                Console.WriteLine("Pobudka! Nowy klient przyszedł!");
            CutHair();
            Console.ReadLine();
        }
       
    }
}