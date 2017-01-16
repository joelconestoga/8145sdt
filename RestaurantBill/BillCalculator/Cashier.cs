using System.Collections.Generic;
using System.Linq;

namespace BillCalculator
{
    public class Cashier
    {
        private decimal foodCharge;
        private List<AdditionalCharger> additionals = new List<AdditionalCharger>();

        public Cashier(decimal foodCharge)
        {
            this.foodCharge = foodCharge;
        }

        public void addCharge(AdditionalCharger additionalCharger)
        {
            additionals.Add(additionalCharger);
        }

        public decimal getTotal()
        {
            foreach(AdditionalCharger charger in additionals)
            {
                foodCharge += charger.getTotal();
            }

            return foodCharge;
        }

        public decimal getAdditionalValue(int v)
        {
            return additionals.ElementAt(v).getTotal();
        }
    }
}
