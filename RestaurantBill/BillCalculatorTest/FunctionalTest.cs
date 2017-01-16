using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BillCalculator;

namespace BillCalculatorTest
{
    [TestClass]
    public class FunctionalTest
    {
        [TestMethod]
        public void calculateBill()
        {
            decimal foodCharge = 100.0m;

            //Instantiate the cashier
            Cashier cashier = new Cashier(foodCharge);

            decimal tipPerc = 15;

            //Instantiate the tip calculator
            AdditionalCharger tipCharger = new TipCharger(tipPerc, foodCharge);

            decimal taxPerc = 7;

            //Instatiate the tax calculator
            AdditionalCharger taxCharger = new TaxCharger(taxPerc, foodCharge);

            //Add additional charges to cashier
            cashier.addCharge(tipCharger);
            cashier.addCharge(taxCharger);

            //Assert charges
            Assert.AreEqual(122, cashier.getTotal());
            Assert.AreEqual(15, cashier.getAdditionalValue(0));
            Assert.AreEqual(7, cashier.getAdditionalValue(1));
        }
    }
}
