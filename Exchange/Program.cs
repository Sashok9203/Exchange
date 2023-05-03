
using System.Collections;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;

namespace Task1
{
    class Program
    {
        
        static void Main(string[] args)
        {
            int x = 0, y = 3;
            int ExchangeTics = 360;
            Exchange ex = new(5, -5, 3, 3, 450);
            Trader trader1 = new("Tom", false);
            Trader trader2 = new("Bil", true);

            ex.MaximumEvent += trader1.MaxTrandDo;
            ex.MaximumEvent += trader2.MaxTrandDo;

            ex.MinimumEvent += trader1.MinTrandDo; 
            ex.MinimumEvent += trader2.MinTrandDo;

            while (ExchangeTics != 0)
            {
                Console.SetCursorPosition(1, 1);
                Console.WriteLine($"Price : {ex.CurrentPrice}");
                Console.SetCursorPosition(x, y);
                ex.Tick();
                x = Console.CursorLeft;
                y = Console.CursorTop;
                ExchangeTics--;
            }

        }

        
    }
    
}