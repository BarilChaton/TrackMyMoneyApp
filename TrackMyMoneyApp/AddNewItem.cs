using System;
using System.Collections.Generic;
using static System.Console;
using System.Linq;
using System.IO;
using System.Text;

namespace TrackMyMoneyApp
{
    class AddNewItem : App
    {

        // transactions list to modify
        //public static List<Transaction> transactionsList = new List<Transaction>();

        public List<Transaction> TransactionsList
        {
            get { return transactionsList; }
        }
        public void RunAddNewItem()
        {
            Console.ForegroundColor = ConsoleColor.White;


            string prompt = @"

#    ______                __   __  ___      __  ___                      
#   /_  __/________ ______/ /__/  |/  /_  __/  |/  /___  ____  ___  __  __
#    / / / ___/ __ `/ ___/ //_/ /|_/ / / / / /|_/ / __ \/ __ \/ _ \/ / / /
#   / / / /  / /_/ / /__/ ,< / /  / / /_/ / /  / / /_/ / / / /  __/ /_/ / 
#  /_/ /_/   \__,_/\___/_/|_/_/  /_/\__, /_/  /_/\____/_/ /_/\___/\__, /  
#                                  /____/                        /____/   " +


"\n\nAdd new input menu!" +
"\nWhat would you like to do?" +
"\n(Use the Arrow keys to cycle through options and press enter to select an option.)\n";
            string[] showItemOptions = { "Add Income", "Add Expense", "Return" };
            Menu mainMenu = new Menu(prompt, showItemOptions);
            int selectedIndex = mainMenu.Run();

            switch (selectedIndex)
            {
                case 0:
                    AddIncome();
                    break;
                case 1:
                    AddExpense();
                    break;
                case 2:
                    RunMainMenu();
                    break;
            }
        }

        public List<Transaction> GetList()
        {
            return transactionsList;
        }

        public void AddIncome() // Adds income to list, makes the user type the thing.
        {
            
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
            string type = "Income";
            Console.WriteLine("Type in income name: ");
            string addCashName = Console.ReadLine();

            Console.WriteLine("Type in income amount");
            double addCash = Double.Parse(Console.ReadLine());

            Console.WriteLine("Which month?");
            //string addMonth = Console.ReadLine();
            DateTime inputDate;
        ERROR1: try
            {
                Console.WriteLine("Type in the date of the income (yyyy-mm-dd)");
                inputDate = DateTime.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You have entered the date wrong, please try again. (yyyy-mm-dd)");
                Console.ResetColor();
                goto ERROR1;
            }

            Transaction transactionInput = new Transaction();

            transactionInput.setTransactionType(type);
            transactionInput.setTransactionProperty(addCashName);
            transactionInput.setTransactionValue(addCash);
            transactionInput.setTransactionMonth(inputDate);
            totalMoney += addCash;

            transactionsList.Add(transactionInput);

            var stringBuilder = new StringBuilder();

            foreach (var transaction in transactionsList)
            {
                Console.Clear();
                stringBuilder.Clear();
                //Console.WriteLine(transaction.toString());
                Console.WriteLine("\nYour new balance is " + totalMoney);
                stringBuilder.AppendLine(transaction.TransactionType.PadRight(25) + transaction.TransactionProperty.PadRight(35) + transaction.TransactionValue.ToString().PadRight(25) + transaction.TransactionMonth.ToString("yyyy-MM-dd"));
            }
            File.AppendAllText(Program.path, stringBuilder.ToString());
            

                Console.WriteLine("Do you wish to add income? Y/N");
            YorN = Console.ReadLine();
            if (YorN.ToLower().Trim() == "y")
            {
                AddIncome();
                YorN = null;
            }
            else if (YorN.ToLower().Trim() == "n")
            {
                Console.Clear();
                RunAddNewItem();
            }

        }
        public void AddExpense() // Adds expenses to the list, makes the user type them in.
        {
            Console.ForegroundColor = ConsoleColor.White;
            string type = "Expense";
            Console.Clear();
            Console.WriteLine("Type in an expense name: ");
            string addCashName = Console.ReadLine();

            Console.WriteLine("Type in the expense amount: ");
            double addCash = Double.Parse(Console.ReadLine());

            Console.WriteLine("Which date?");
            DateTime inputDate;
        ERROR1: try
            {
                Console.WriteLine("Type in the date of the expense (yyyy-mm-dd)");
                inputDate = DateTime.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You have entered the date wrong, please try again. (yyyy-mm-dd)");
                Console.ResetColor();
                goto ERROR1;
            }

            Transaction transactionInput = new Transaction();

            transactionInput.setTransactionType(type);
            transactionInput.setTransactionProperty(addCashName);
            transactionInput.setTransactionValue(addCash);
            transactionInput.setTransactionMonth(inputDate);
            

            if (totalMoney < addCash)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You have no balance on your account, and cannot buy new things.");
                if (transactionsList.Count > 0)
                {
                    transactionsList.RemoveAt(transactionsList.Count - 1);
                }
                Console.ReadLine();
                RunAddNewItem();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.White;
                transactionsList.Add(transactionInput);
                totalMoney -= addCash;
                

                File.AppendAllLines(@"C:\Users\Elev\source\repos\TrackMyMoneyApp\transactions.txt", (IEnumerable<string>)transactionsList);

                foreach (var transaction in transactionsList)
                {
                    Console.Clear();
                    //Console.WriteLine(transaction.toString());
                    Console.WriteLine("\nYour new balance is " + totalMoney);

                    
                }
                File.WriteAllText(Program.path, transactionsList.ToString());
                Console.WriteLine("Do you wish to add an expense? Y/N");
                YorN = Console.ReadLine();
                if (YorN.ToLower().Trim() == "y")
                {
                    AddExpense();
                    YorN = null;
                }
                else if (YorN.ToLower().Trim() == "n")
                {
                    Console.Clear();
                    RunAddNewItem();
                }
            }

            
        }
        public void Print()
        {
            Console.WriteLine("Your current balance is: " + totalMoney + " kr\n");
            Console.WriteLine("Your Incomes/Expenses: \n\n");
            Console.WriteLine("Transaction Type:".PadRight(25) + "Transaction Name:".PadRight(35) + "Amount:".PadRight(25) + "Date:".PadRight(25));
            Console.WriteLine("\n#==================================================================================================#\n");

            // Sort the items first by date and then by type:
            transactionsList = transactionsList.OrderBy(transaction => transaction.TransactionMonth).ThenBy(transaction => transaction.TransactionType).ToList();
            string[] lines = System.IO.File.ReadAllLines(Program.path);
            foreach (string line in lines)
            {
                Console.WriteLine("\t" + line);
                //Console.WriteLine(transaction.TransactionType.PadRight(25) + transaction.TransactionProperty.PadRight(35) + transaction.TransactionValue.ToString().PadRight(25) + transaction.TransactionMonth.ToString("yyyy-MM-dd"));
            }
            Console.WriteLine("\nPress any key to return to main menu.");
            ReadKey(true);
            RunMainMenu();
        }
    }
}
