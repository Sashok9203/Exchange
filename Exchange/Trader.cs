using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    internal class Trader
    {
        public string Name { get; init; }

        public bool   Bought { get; private set; }

        public Trader(string name,bool bought)
        {
            Name = name;
            Bought = bought;
        }

        public void MaxTrandDo(int price)
        {
            if (Bought)
            {
                string tmp = $"Trider \"{Name}\" sold at the price {price}";
                Console.WriteLine(tmp);
                writeToFile(tmp);
                Bought = false;
            }
        }

        public void MinTrandDo(int price)
        {
            if (!Bought)
            {
                string tmp = $"Trider \"{Name}\" bought at the price {price}";
                Console.WriteLine(tmp);
                writeToFile(tmp);
                Bought = true;
            }
        }

        private void writeToFile(string? str)
        {
            using (StreamWriter tw = new(new FileStream("log.txt", FileMode.Append, FileAccess.Write)))
            {
                tw.WriteLine(str);
            }
        }
    }

    
}
