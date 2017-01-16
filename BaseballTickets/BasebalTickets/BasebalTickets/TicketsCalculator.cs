using System;
using System.Collections.Generic;

namespace BasebalTickets
{
    public class TicketsCalculator
    {

        private List<ClassCalculator> seatsCalculators = new List<ClassCalculator>();

        public void addTickets(ClassCalculator newCalc)
        {
            seatsCalculators. Add(newCalc);
        }

        public decimal getTotal(int v)
        {
            return seatsCalculators[v].getTotal();
        }

        public decimal getGrandTotal()
        {
            throw new NotImplementedException();
        }
    }
}