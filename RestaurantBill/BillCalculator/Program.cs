using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Please, provide the food charge/price: ");
            decimal food = Convert.ToDecimal(Console.ReadLine());

            Cashier cashier = new Cashier(food);
            AdditionalCharger tip = new TipCharger(15, food);
            AdditionalCharger tax = new TaxCharger(7, food);

            cashier.addCharge(tip);
            cashier.addCharge(tax);

            Console.WriteLine("\nFood.....{0,7:c2}", food);
            Console.WriteLine("Tip......{0,7:c2}", cashier.getAdditionalValue(0));
            Console.WriteLine("Tax......{0,7:c2}", cashier.getAdditionalValue(1));
            Console.WriteLine("\n-----------------\n");
            Console.WriteLine("TOTAL....{0,7:c2}", cashier.getTotal());
            Console.WriteLine("\nThank you, and come again soon!\n");

            Console.ReadKey();
        }
    }
}
