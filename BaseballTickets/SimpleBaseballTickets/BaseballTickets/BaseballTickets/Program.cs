using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseballTickets
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal aClass = 0;
            while (aClass < 1)
            {
                Console.Write("How many tickets for Class A: ");
                aClass = readValue();
            }

            decimal bClass = 0;
            while (bClass < 1)
            {
                Console.Write("How many tickets for Class B: ");
                bClass = readValue();
            }

            decimal cClass = 0;
            while (cClass < 1)
            {
                Console.Write("How many tickets for Class C: ");
                cClass = readValue();
            }

            decimal aTotal = aClass * 15;
            decimal bTotal = bClass * 12;
            decimal cTotal = cClass * 9;

            Console.WriteLine("\nClass A Income......{0,8:c2}", aTotal);
            Console.WriteLine("Class B Income......{0,8:c2}", bTotal);
            Console.WriteLine("Class C Income......{0,8:c2}", cTotal);
            Console.WriteLine("\n-------------------");
            Console.WriteLine("\n  TOTAL Income......{0,8:c2}", aTotal + bTotal + cTotal);

            Console.ReadKey();
        }

        private static decimal readValue()
        {
            decimal quantity = 0;

            try
            {
                quantity = Convert.ToDecimal(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine("Invalid entry!");
            }

            return quantity;
        }
    }
}
