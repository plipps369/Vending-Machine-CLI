using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Capstone
{
    public class VendingMachine
    {
        /// <summary>
        /// Declaring balance, setting it to 0, and initializing Inventory
        /// </summary>
        public decimal Balance { get; private set; } = 0;
        public Dictionary<string, Product> Inventory { get; private set; } = new Dictionary<string, Product>();

        public VendingMachine(string file)
        {
            CreateInventory(file);
        }
           
        /// <summary>
        /// Reading inventory from vendingmachine.txt
        /// </summary>
        /// <param name="file"></param>
        public void CreateInventory(string file)
        { 

            string directory = Environment.CurrentDirectory;
            string fullPath = Path.Combine(directory, file);

            try
            {
                using (StreamReader sr = new StreamReader(fullPath))
                {
                    while (!sr.EndOfStream)
                    {
                        //Creating "information" array from each line which holds the slot number, name, price, and type
                        //of each item
                        string line = sr.ReadLine();
                        string[] information = line.Split("|");
                        string slot = information[0];
                        string name = information[1];
                        decimal price = decimal.Parse(information[2]);
                        string type = information[3];
                        

                        if (type == "Chip")
                        {
                            Chip chip = new Chip(name, price);
                            Inventory.Add(information[0], chip);
                        }
                        else if (type == "Drink")
                        {
                            Drink drink = new Drink(name, price);
                            Inventory.Add(information[0], drink);
                        }
                        else if (type == "Candy")
                        {
                            Candy candy = new Candy(name, price);
                            Inventory.Add(information[0], candy);
                        }
                        else if (type == "Gum")
                        {
                            Gum gum = new Gum(name, price);
                            Inventory.Add(information[0], gum);
                        }
                    }
                }
            }

            catch (Exception e)
            {
                Console.WriteLine("Invalid path. Please try again: " + e.GetType() + e.Message);
            }
        }

        public decimal CashOut()
        {
            decimal oldBalance = Balance;
            oldBalance = 0;
            Log.ChangeLog(oldBalance, Balance);
            return Balance;
        }


        public Product PurchaseProduct(string selection)
        {

                if (Inventory.ContainsKey(selection))
                {

                    if (Balance > Inventory[selection].Price)
                    {
                    decimal oldBalance = Balance;
                    Inventory[selection].PurchaseOneItem();
                    Balance -= Inventory[selection].Price;
                    Log.PurchaseLog(selection, Inventory[selection].Name, oldBalance , Balance);
                    }

                }
                else
                {
                    throw new InvalidSelectionException();
                }

            return Inventory[selection];
        }

        /// <summary>
        /// Updating balance from moneyFed in Cli
        /// </summary>
        /// <param name="moneyFed"></param>
        public void UpdateBalance(decimal moneyFed)
        {
            Balance += moneyFed;
            Log.FeedMoneyLog(moneyFed, Balance);
        }
    }
}
