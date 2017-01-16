using System;

namespace BillCalculator
{
    public class TaxCharger : AdditionalCharger
    {
        private decimal foodCharge;
        private decimal taxPerc;

        public TaxCharger(decimal taxPerc, decimal foodCharge)
        {
            this.taxPerc = taxPerc;
            this.foodCharge = foodCharge;
        }

        public decimal getTotal()
        {
            return foodCharge * (taxPerc / 100);
        }
    }
}