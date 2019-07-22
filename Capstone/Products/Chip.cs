using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    public class Chip : Product
    {
        public Chip(string name, decimal price) : base(name, price)
        {

        }
        public override string MakeSound()
        {
            return "Crunch, Crunch, Yum!";
        }
    }
}
