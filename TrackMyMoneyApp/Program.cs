using System;
using System.IO;
using System.Text;
namespace TrackMyMoneyApp
{
    class Program
    {
        public static string path = string.Join(AppDomain.CurrentDomain.BaseDirectory, "transactions.txt");
        public static string path2 = string.Join(AppDomain.CurrentDomain.BaseDirectory, "balance.txt");
        static void Main(string[] args)
        {
            // It creates the file to store list of transactions. Made sure it is the first thing it does.
            Console.WriteLine("Checking for file: transactions.txt");

            if (File.Exists(path))
            {
                Console.WriteLine("File transaction.txt exists.");
            }
            else
            {
                using (StreamWriter sw = File.CreateText(path)) ;
                Console.WriteLine("File transactions.txt has been created at: " + AppDomain.CurrentDomain.BaseDirectory);
            }

            Console.WriteLine("Checking for file: balance.txt");

            if (File.Exists(path2))
            {
                Console.WriteLine("File exists.");
            }
            else
            {
                Console.WriteLine("File balance.txt has been created at: " + AppDomain.CurrentDomain.BaseDirectory);
            }

            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();

            App app = new App();
            app.Start();
        }

        
    }
}
