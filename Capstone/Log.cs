using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Capstone
{
    public class Log
    {

        public static void FeedMoneyLog(decimal moneyFed, decimal newBalance)
        {
            string directory = Environment.CurrentDirectory;
            string outputFile = "transactionlog.txt";
            string outFullPath = Path.Combine(directory, outputFile);
            using (StreamWriter sw = new StreamWriter(outFullPath, true))
            {
                sw.WriteLine(DateTime.Now + " FEED MONEY " + moneyFed + " " + newBalance);
            }
        }

        public static void PurchaseLog(string selection, string name, decimal oldBalance, decimal balance)
        {
            string directory = Environment.CurrentDirectory;
            string outputFile = "transactionlog.txt";
            string outFullPath = Path.Combine(directory, outputFile);
            using (StreamWriter sw = new StreamWriter(outFullPath, true))
            {
                sw.WriteLine(DateTime.Now + " " + name + " " + oldBalance + " " + balance);
            }
        }

        public static void ChangeLog(decimal oldBalance, decimal Balance)
        {
            string directory = Environment.CurrentDirectory;
            string outputFile = "transactionlog.txt";
            string outFullPath = Path.Combine(directory, outputFile);
            using (StreamWriter sw = new StreamWriter(outFullPath, true))
            {
                sw.WriteLine(DateTime.Now + " GIVE CHANGE " + oldBalance + " " + Balance);
            }
        }
    }
}
