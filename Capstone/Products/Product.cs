using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    public abstract class Product
    {

        //Name of the product
        public string Name { get; set; }

        //Price of the product
        public decimal Price { get; set; }

        public int Quantity { get; private set; } = 5;

        //Sound the product makes when purchased
        public abstract string MakeSound();
       

        public Product(string name, decimal price)
        {
            this.Name = name;
            
            this.Price = price;
        }

        public void PurchaseOneItem()
        {
            if (Quantity > 0)
            {
                Quantity--;
            }
            else
            {
                throw new OutOfStockException();
            }
        }
    }
}
