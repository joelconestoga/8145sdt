using System;

namespace BillCalculator
{
    public class TipCharger : AdditionalCharger
    {
        private decimal foodCharge;
        private decimal tipPerc;

        public TipCharger(decimal tipPerc, decimal foodCharge)
        {
            this.tipPerc = tipPerc;
            this.foodCharge = foodCharge;
        }

        public decimal getTotal()
        {
            return foodCharge * (tipPerc/100);
        }
    }
}