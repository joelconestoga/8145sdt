using System;

namespace BasebalTickets
{
    public class ACalculator : ClassCalculator
    {
        private int v;

        public ACalculator(int v)
        {
            this.v = v;
        }

        public decimal getTotal()
        {
            throw new NotImplementedException();
        }
    }
}