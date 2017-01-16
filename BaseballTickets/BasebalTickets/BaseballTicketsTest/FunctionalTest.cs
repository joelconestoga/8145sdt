using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BasebalTickets;

namespace BaseballTicketsTest
{
    [TestClass]
    public class FunctionalTest
    {
        [TestMethod]
        public void calculateTicketsForClassABC()
        {
            //Create ticketsCalculator
            TicketsCalculator calc = new TicketsCalculator();

            //Create aCalculator
            ClassCalculator aCalc = new ACalculator(1);

            //Create bCalculator
            ClassCalculator bCalc = new BCalculator(2);

            //Create cCalculator
            ClassCalculator cCalc = new CCalculator(3);

            //Add calculators to ticketsCalculator
            calc.addTickets(aCalc);
            calc.addTickets(bCalc);
            calc.addTickets(cCalc);

            //Calculate each class total
            Assert.AreEqual(15, calc.getTotal(0));
            Assert.AreEqual(24, calc.getTotal(1));
            Assert.AreEqual(27, calc.getTotal(2));

            //Calculate the grand total
            Assert.AreEqual(66, calc.getGrandTotal());

        }
    }
}
