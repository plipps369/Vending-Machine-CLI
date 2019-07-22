using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    public class Gum : Product
    {
        public Gum(string name, decimal price) : base(name, price)
        {

        }
        public override string MakeSound()
        {
            return "Chew, Chew, Yum!";
        }
    }
}
