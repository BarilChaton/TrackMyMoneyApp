using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackMyMoneyApp
{
    class ShowList : App
    {
        //List<Transaction> transactionsShowList = new List<Transaction>();
        
        public void ShowItems()
        {
            string prompt = @"

#    ______                __   __  ___      __  ___                      
#   /_  __/________ ______/ /__/  |/  /_  __/  |/  /___  ____  ___  __  __
#    / / / ___/ __ `/ ___/ //_/ /|_/ / / / / /|_/ / __ \/ __ \/ _ \/ / / /
#   / / / /  / /_/ / /__/ ,< / /  / / /_/ / /  / / /_/ / / / /  __/ /_/ / 
#  /_/ /_/   \__,_/\___/_/|_/_/  /_/\__, /_/  /_/\____/_/ /_/\___/\__, /  
#                                  /____/                        /____/   " +


            "\n\nShow Items Menu!" +
            "\nWhat would you like to see?" +
            "\n(Use the Arrow keys to cycle through options and press enter to select an option.)\n";
            
            string[] options = { "All", "Income(s)", "Expense(s)", "Return" };
            Menu mainMenu = new Menu(prompt, options);
            int selectedIndex = mainMenu.Run();

            switch (selectedIndex)
            {
                case 0:
                    AllItems();
                    break;
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    RunMainMenu();
                    break;
            }
        }

        AddNewItem addNewItem = new AddNewItem();

        public void AllItems()
        {
            Console.Clear();
            addNewItem.Print();
        }
    }
}
