using System;
using System.IO;
using System.Text;
namespace TrackMyMoneyApp
{
    class Program
    {
        public static string path = string.Join(AppDomain.CurrentDomain.BaseDirectory, "transactions.txt");
        static void Main(string[] args)
        {
            // It creates the file. Made sure it is the first thing it does.
            //public string path = string.Join(AppDomain.CurrentDomain.BaseDirectory, "transactions.txt");
            Console.WriteLine("Checking for file: transactions.txt");

            if (File.Exists(path))
            {
                Console.WriteLine("File exists.");
            }
            else
            {
                using (StreamWriter sw = File.CreateText(path)) ;
                Console.WriteLine("File has been created at: " + AppDomain.CurrentDomain.BaseDirectory);
            }
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();

            App app = new App();
            app.Start();
        }

        
    }
}
