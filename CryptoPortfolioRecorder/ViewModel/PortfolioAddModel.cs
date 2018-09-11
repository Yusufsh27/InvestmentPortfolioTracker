using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoPortfolioRecorder.ViewModel
{
    public class Portfolios
    {
        public string Portfolio { get; set; }
    }

    public class Coins
    {
        public string Name { get; set; }
        public double Amount { get; set; }
        public DateTime DateTimeBought { get; set; }
        public double PriceBought { get; set; }
    }

    public class PortfolioAddModel
    {
        //Should Add AutoComplete
        public string Name { get; set; }
        public double Amount { get; set; }
        public DateTime DateTimeBought { get; set; }
        public double PriceBought { get; set; }
    }
}
