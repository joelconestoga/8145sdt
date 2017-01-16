using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BillCalculator;

namespace BillCalculatorTest
{
    [TestClass]
    public class CashierTest
    {

        Cashier subject = new Cashier(100);

        [TestMethod]
        public void getTotal()
        {
            Assert.AreEqual(100, subject.getTotal());
        }

        [TestMethod]
        public void getTotalWithTip()
        {
            subject.addCharge(new AdditionalChargerMock(10));
            Assert.AreEqual(110, subject.getTotal());
        }

        [TestMethod]
        public void getTotalWithTax()
        {
            subject.addCharge(new AdditionalChargerMock(5));
            Assert.AreEqual(105, subject.getTotal());
        }

        [TestMethod]
        public void getTotalWithTipAndTax()
        {
            subject.addCharge(new AdditionalChargerMock(10));
            subject.addCharge(new AdditionalChargerMock(5));
            Assert.AreEqual(115, subject.getTotal());
        }

        [TestMethod]
        public void getAdditionalValue()
        {
            subject.addCharge(new AdditionalChargerMock(10));
            subject.addCharge(new AdditionalChargerMock(5));
            Assert.AreEqual(10, subject.getAdditionalValue(0));
            Assert.AreEqual(5, subject.getAdditionalValue(1));
        }

    }

    internal class AdditionalChargerMock : AdditionalCharger
    {
        private int v;

        public AdditionalChargerMock(int v)
        {
            this.v = v;
        }

        public decimal getTotal()
        {
            return v;
        }
    }

}
