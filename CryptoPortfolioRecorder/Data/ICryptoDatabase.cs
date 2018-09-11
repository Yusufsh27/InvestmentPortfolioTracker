using CryptoPortfolioRecorder.Models;
using CryptoPortfolioRecorder.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoPortfolioRecorder.Data
{
    public interface ICryptoDatabase
    {
        IEnumerable<Crypto> GetAll();
        void Add(Crypto crypto);
        void Remove(PortfolioRemoveModel crypto);
        //Crypto Get(string cryptoName);
    }
}
