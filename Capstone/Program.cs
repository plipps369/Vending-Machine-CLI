using System;

namespace Capstone
{
    public class Program
    {
        static void Main(string[] args)
        {

            VendingMachine vm = new VendingMachine("VendingMachine.txt");
            CLI ourCLI = new CLI(vm);
            ourCLI.Run();
        }
    }
}
