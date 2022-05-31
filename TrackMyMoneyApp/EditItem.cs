using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackMyMoneyApp
{
    class EditItem : AddNewItem
    {
        public void RunEditItem()
        {
            Console.ForegroundColor = ConsoleColor.White;


            string prompt = @"

#    ______                __   __  ___      __  ___                      
#   /_  __/________ ______/ /__/  |/  /_  __/  |/  /___  ____  ___  __  __
#    / / / ___/ __ `/ ___/ //_/ /|_/ / / / / /|_/ / __ \/ __ \/ _ \/ / / /
#   / / / /  / /_/ / /__/ ,< / /  / / /_/ / /  / / /_/ / / / /  __/ /_/ / 
#  /_/ /_/   \__,_/\___/_/|_/_/  /_/\__, /_/  /_/\____/_/ /_/\___/\__, /  
#                                  /____/                        /____/   " +


"\n\nEdit/Remove input menu!" +
"\nWhat would you like to edit/remove?" +
"\n(Use the Arrow keys to cycle through options and press enter to select an option.)\n";
            string[] showItemOptions = { "Edit List", "Remove from List", "Return" };
            Menu mainMenu = new Menu(prompt, showItemOptions);
            int selectedIndex = mainMenu.Run();

            switch (selectedIndex)
            {
                case 0:
                    EditListItem();
                    break;
                case 1:
                    RemoveListItem();
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

        public void EditListItem()
        {
            AddNewItem addNewItem = new AddNewItem();
            Console.Clear();
            addNewItem.Print();


            //string prompt = "Select which transaction you wish to edit:";

            //for (int i = 0; i < transactionsList.Count; i++)
            //{
            //    Console.WriteLine(transactionsList[i]);
            //}

            //var alltItems = transactionsList;
            //string[] showItemOptions = {transactionsList.ToString()};
            //Menu mainMenu = new Menu(prompt, showItemOptions);
            //int selectedIndex = mainMenu.Run();




            // Editing code here...

        }

        public void RemoveListItem()
        {

        }
    }
}
