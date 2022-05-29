using System;
using System.Collections.Generic;
using static System.Console;

namespace TrackMyMoneyApp
{
    class App
    {
        public static List<Transaction> transactionsList = new List<Transaction>();
        public string YorN; // Yes or No answer
        // Not set in stone.
        public static double totalMoney = 0;


        public void Start()
        {
            Title = "TrackMyMoney";
            RunMainMenu();
        }

        public void RunMainMenu()
        {
            Console.ForegroundColor = ConsoleColor.White;

            string prompt = @"

#    ______                __   __  ___      __  ___                      
#   /_  __/________ ______/ /__/  |/  /_  __/  |/  /___  ____  ___  __  __
#    / / / ___/ __ `/ ___/ //_/ /|_/ / / / / /|_/ / __ \/ __ \/ _ \/ / / /
#   / / / /  / /_/ / /__/ ,< / /  / / /_/ / /  / / /_/ / / / /  __/ /_/ / 
#  /_/ /_/   \__,_/\___/_/|_/_/  /_/\__, /_/  /_/\____/_/ /_/\___/\__, /  
#                                  /____/                        /____/  " +
"\n\nWelcome to the TrackMyMoney app!" +
"\nYou have " + totalMoney + "kr on your account" +
"\nWhat would you like to do?" +
"\n(Use the Arrow keys to cycle through options and press enter to select an option.)\n";



            string[] options = { "Show Items (All/Expense(s)/Income(s))", "Add new Expense/Income", "Edit Item(edit, remove)", "Save and Exit" };
            Menu mainMenu = new Menu(prompt, options);
            int selectedIndex = mainMenu.Run();


            switch (selectedIndex)
            {
                case 0:
                    ShowItems();
                    break;
                case 1:
                    AddNew();
                    break;
                case 2:
                    EditItem();
                    break;
                case 3:
                    SaveAndExit();
                    break;
            }
        }

        //==============================
        // Options from the main menu.
        //==============================

        private void SaveAndExit()
        {
            WriteLine("\nSaving your inputs into file...");
            WriteLine("\nPress any key to exit...");
            ReadKey(true);
            Environment.Exit(0);
        }

        private void EditItem()
        {
            EditItem editItem = new EditItem();
            editItem.RunEditItem();
        }

        private void AddNew()
        {
            AddNewItem addNewItem = new AddNewItem();
            addNewItem.RunAddNewItem();
        }

        private void ShowItems()
        {
            ShowList showList = new ShowList();
            showList.ShowItems();
        }
    }
}
