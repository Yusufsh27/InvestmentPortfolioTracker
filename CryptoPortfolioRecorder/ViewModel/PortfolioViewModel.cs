using CryptoPortfolioRecorder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoPortfolioRecorder.ViewModel
{
    public class PortfolioViewModel
    {
        public IEnumerable<Crypto> cryptos { get; set; }
        public double totalPriceInvested = 0;
        public double totalCurrentPrice = 0;
        public double totalPercentChange = 0;

        public PortfolioViewModel(IEnumerable<Crypto> cryptoList)
        {
            cryptos = cryptoList;
            CalcualteTotalInvested();
            CalcualteTotalCurrentPrice();
            totalPercentChange = CalculateChange(totalPriceInvested, totalCurrentPrice);
        }

        private void CalcualteTotalInvested()
        {
            foreach (var crypto in cryptos)
            {
                totalPriceInvested += crypto.AmountSpent;
            }
        }

        private void CalcualteTotalCurrentPrice()
        {
            foreach (var crypto in cryptos)
            {
                totalCurrentPrice += crypto.CurrentTotal;
            }
        }

        public static double CalculateChange(double previous, double current)
        {
            if (previous == 0)
                throw new InvalidOperationException();

            var change = current - previous;

            return Math.Round(((double)change / previous) * 100, 2);
        }

    }
}
