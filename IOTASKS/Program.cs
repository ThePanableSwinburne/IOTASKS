using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.IO;

namespace IOTASKS
{
    public class Items
    {

        public string Title { get; set; }
        public int Quantity { get; set; }
        public int UnitPrice { get; set; }
        public Items(string title, int quantity, int unitPrice)
        {
            Title = title;
            Quantity = quantity;
            UnitPrice = unitPrice;
        }

    }

    internal class Program
    {
        public static List<Items> ItemsList = new List<Items>(); 

        public static void GetSelection()
        {
            Console.WriteLine("1. Add New Item");
            Console.WriteLine("2. List All Items");
            Console.WriteLine("3. Show Total Cost");
            Console.WriteLine("4. Clear List");
            Console.WriteLine("5. Save List");
            Console.WriteLine("6. Exit");

            switch (Console.ReadLine())
            {
                case "1":
                    AddNewItem();
                    break;
                case "2":
                    ListAllItems();
                    break;
                case "3":
                    ShowTotalCost();
                    break;
                case "4":
                    ClearList();
                    break;
                case "5":
                    SaveList();
                    break;
                case "6":
                    Exit();
                    break;
                default:
                    Console.WriteLine("Incorrect option, try again");
                    GetSelection();
                    break;
            }
        }

        public static void AddNewItem()
        {
            Console.WriteLine("You've selected to add a new item");
            
            Console.WriteLine("Please enter the title of the item: ");
            string title = Console.ReadLine();
            Console.WriteLine("Please enter the quantity of the item: ");
            int quantity = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Please enter the unit price of the item: ");
            int unitPrice = Int32.Parse(Console.ReadLine());

            ItemsList.Add(new Items(title, quantity, unitPrice));
            Console.WriteLine("You have successfully added an item");
            
            GetSelection();
        }

        public static void ListAllItems()
        {
            Console.WriteLine("Items: ");
            foreach (var item in ItemsList)
            {
                Console.WriteLine($"Title: {item.Title}, Quantity {item.Quantity}, Unit Price: {item.UnitPrice}");
            }
            GetSelection();
        }

        public static void ShowTotalCost()
        {
            int sum = 0;
            foreach (var item in ItemsList)
            {
                var totalItemCost = item.Quantity * item.UnitPrice;
                sum += totalItemCost;
            }
            Console.WriteLine($"Total cost is {sum}");
            GetSelection();
        }

        public static void ClearList()
        {
           ItemsList = new List<Items>(); 
           GetSelection();
        }

        public static void SaveList()
        {
            StreamWriter writer = new StreamWriter($@"{Environment.CurrentDirectory}\ShoppingList.csv");
            foreach (var item in ItemsList)
            {
                writer.WriteLine($"{item.Title},{item.UnitPrice},{item.Quantity}");
            }
            writer.Close();
            GetSelection();
        }

        public static void Exit()
        {
            Console.WriteLine("Thanks for using the Shopping List App");
            Console.WriteLine("Exiting...");
        }

        static void Main(string[] args)
        {
            GetSelection();
        }
    }
}
