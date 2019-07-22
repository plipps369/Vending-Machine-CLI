using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    public class Drink : Product
    {
        public Drink(string name, decimal price) : base(name, price)
        {

        }
        public override string MakeSound()
        {
            return "Glug, Glug, Yum!";
        }
    }
}
