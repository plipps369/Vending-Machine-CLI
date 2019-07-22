using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    public class Candy : Product
    {
        public Candy(string name, decimal price) :base(name, price)
        {
            
        }
        public override string MakeSound()
        {
            return "Munch, Munch, Yum!";
        }
    }
}
