using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Capstone
{
    public class CLI
    {
        
        public decimal moneyFed { get; set; }
        private VendingMachine _vm;

        public CLI(VendingMachine vm)
        {
            this._vm = vm;
        }
        
        private void PurchaseItem()
        {
            
            DisplayMenu();
            Console.WriteLine("Please enter item selection:");
            string customerSelection = Console.ReadLine();
            try
            {
                var item = _vm.PurchaseProduct(customerSelection.ToUpper());
                Console.WriteLine(item.MakeSound());
            }
            catch(InsufficientFundsException)
            {
                Console.WriteLine("Insufficient funds");
            }
            catch (InvalidSelectionException)
            {
                Console.WriteLine("Invalid selection");
            }
            catch (OutOfStockException)
            {
                Console.WriteLine("Currently out of stock");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadKey();
        }

        private void MakeChange()
        {
            decimal change = _vm.CashOut();
            Console.WriteLine("Please take your change: $" + change);
        }

        public void Run()
        {
            int customerInput = 0;
            while (customerInput != 3)
            {
                Console.Clear();
                Console.WriteLine("Welcome to Vendo-Matic 9001");
                Console.WriteLine();
                Console.WriteLine("Please select:");
                Console.WriteLine("1) Feed Money:");
                Console.WriteLine("2) Select Product:");
                Console.WriteLine("3) Finish Transaction:");
                try
                {
                    customerInput = int.Parse(Console.ReadLine());
                    if (customerInput == 000000)
                    {
                        Console.WriteLine("Hello master, here is the secret log for the day:");
                    }
                    else if (customerInput == 1)
                    {
                        Console.WriteLine("Please enter amount");
                        moneyFed = decimal.Parse(Console.ReadLine());
                        if (moneyFed < 0)
                        {
                            Console.WriteLine("Invalid input. Please enter positive amount:");
                            moneyFed = decimal.Parse(Console.ReadLine());
                        }
                        else
                        {
                            _vm.UpdateBalance(moneyFed);
                            Console.WriteLine("Your current balance is " + _vm.Balance);
                        }
                    }
                    else if (customerInput == 2)
                    {
                        PurchaseItem();
                    }
                    else if (customerInput == 3)
                    {
                        MakeChange();
                        Console.WriteLine("Thank you, come again!");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Invalid input. Please come again! " + e.GetType() + e.Message);
                }
                Console.ReadLine();
            }
        }
        
        private void DisplayMenu()
        {
            foreach (KeyValuePair<string, Product> kvp in _vm.Inventory)
            {
                Console.WriteLine(kvp.Key + " | " + kvp.Value.Name + " | " + "$" + kvp.Value.Price + " | " + kvp.Value.Quantity);
            }
        }
    }
}
