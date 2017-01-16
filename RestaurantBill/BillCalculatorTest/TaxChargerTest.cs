using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BillCalculator;

namespace BillCalculatorTest
{
    [TestClass]
    public class TaxChargerTest
    {
        TaxCharger subject = new TaxCharger(7, 200);

        [TestMethod]
        public void getTotal()
        {
            Assert.AreEqual(14, subject.getTotal());
        }
    }
}
