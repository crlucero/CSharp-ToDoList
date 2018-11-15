using System.Collections.Generic;
using System;


namespace ToDoList.Models
{
    public class Program
    {
        public class Item
        {
            private string _description;
            private static List<Item> _instances = new List<Item> { };

            public Item(string description)
            {
                _description = description;
                _instances.Add(this);
            }

            public string GetDescription()
            {
                return _description;
            }

            public void SetDescription(string newDescription)
            {
                _description = newDescription;
            }

            public static List<Item> GetAll()
            {
                return _instances;
            }

            public static void ClearAll()
            {
                _instances.Clear();
            }
        }

        public static void Main()
        {
            Console.WriteLine("Welcome to the To Do List.");
            Console.WriteLine("Would you like to add an item to your list or view your list? (Add/View/Exit).");
            string userChoice = (Console.ReadLine().ToLower());

            while (userChoice != "exit")
            {
                if (userChoice == "add")
                {
                    Add();
                    userChoice = (Console.ReadLine().ToLower());

                }
                else if (userChoice == "view")
                {
                    View();
                    userChoice = (Console.ReadLine().ToLower());

                }
                else if (userChoice == "exit")
                {
                    return;
                }
                else
                {
                    Admonish();
                    userChoice = (Console.ReadLine().ToLower());
                }
            }
        }
        public static void Add()
        {
            Console.WriteLine("Please enter the description for your new item.");
            string userItem = Console.ReadLine();
            Item newItem = new Item(userItem);
            Console.WriteLine(newItem.GetDescription() + " has been added to your list. Would you like to add another item to your list or view your list? (Add/View/Exit).");
        }

        public static void View()
        {
            List<Item> result = Item.GetAll();
            
            //Console.WriteLine(result); (this line was commented out because you can't print a list like this, it just returns "System.Collections.Generic.List`1[ToDoList.Models.Program+Item]")
            
            //foreach loop is easy way to solve
            foreach(Item item in result) {
                Console.WriteLine("TODO: " + item.GetDescription());
            }

            //for loop is a good way to number list items
            for (int i = 0; i < result.Count; i++) {
                Console.WriteLine(i + ": " + result[i].GetDescription());
            }
            Console.WriteLine("This is your list. Would you like to add an item or view your list again? (Add/View/Exit).");
        }

        public static void Admonish()
        {
            Console.WriteLine("Please enter a valid choice: Add/View/Exit");
        }
    }
}