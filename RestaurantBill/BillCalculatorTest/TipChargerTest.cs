using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BillCalculator;

namespace BillCalculatorTest
{
    [TestClass]
    public class TipChargerTest
    {
        TipCharger subject = new TipCharger(7, 300);

        [TestMethod]
        public void getTotal()
        {
            Assert.AreEqual(21, subject.getTotal());
        }
    }
}
