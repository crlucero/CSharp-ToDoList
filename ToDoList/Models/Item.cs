using System.Collections.Generic;
using System;


namespace ToDoList.Models
{
    public class Program
    {
        public class Item
        {
            private string _description;
            private static List<Item> _instances = new List<Item> {};

            public Item (string description)
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
            string userChoice = Console.ReadLine();

            while (userChoice != "Exit")
            {
                if (userChoice == "Add")
                {
                    Add();
                    userChoice = Console.ReadLine();
                    
                }
                else if (userChoice == "View")
                {
                    View();
                    userChoice = Console.ReadLine();
                    
                }
                else
                {
                    return;
                }
            }
        }
            public static void Add()
            {
                Console.WriteLine("Please enter the description for your new item.");
                string userItem = Console.ReadLine();
                Item newItem = new Item(userItem);
                List<Item> newList = new List<Item> {newItem};

                Console.WriteLine(userItem + " has been added to your list. Would you like to add another item to your list or view your list? (Add/View/Exit).");

            }

            public static void View()
            {
                List<Item> result = Item.GetAll();
                Console.WriteLine(result);
                Console.WriteLine("This is your list. Would you like to add an item or view your list again? (Add/View/Exit).");

            }
        
    }
}