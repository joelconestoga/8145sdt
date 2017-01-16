using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.Write("Please, enter the Celsius temperature: ");
            decimal cel = Convert.ToDecimal(Console.ReadLine());

            decimal fah = (cel * 9/5) + 32;

            Console.WriteLine("\n{0} Celsius is equal to {1} Fahrenheit.", cel, fah);
            Console.ReadKey();
        }
    }
}
