using CryptoPortfolioRecorder.Models;
using CryptoPortfolioRecorder.ViewModel;
using Microsoft.EntityFrameworkCore.Internal;
using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace CryptoPortfolioRecorder.Data
{
    public class CryptoDatabase : ICryptoDatabase
    {
        private MongoClient client;
        private IMongoDatabase db;
        private IMongoCollection<Portfolios> collec;
        public List<Crypto> cryptoList;

        

        public CryptoDatabase()
        {
            //Connects to mongoDb
            client = new MongoClient("mongodb://localhost:27017");

            //Gets the database
            db = client.GetDatabase("CryptoAccounts");

            //Gets the collection
            collec = db.GetCollection<Portfolios>("Portfolios");

            var portfolio1 = collec.Find(p => p.Portfolio == "Portfolio1");


            cryptoList = new List<Crypto>
            {
                new Crypto("ETH", 9.478, DateTime.Parse("09/05/2018"), 257.90),
                new Crypto("XLM", 269, DateTime.Parse("02/05/2018"), 0.29),
                new Crypto("NEO", 5.294, DateTime.Parse("02/05/2018"), 67.71),
                new Crypto("WTC", 86.915, DateTime.Parse("02/05/2018"), 15),
            };
        }

        //public Crypto Get(string cryptoName)
        //{
        //    var crypto = new ObjectId(cryptoName);
        //    Crypto retModel = new Crypto();
        //    retModel.Name = cryptoName;
        //    retModel.Amount = collec[cryptoName: "Amount"];
        //    //retModel.DateTimeBought = collec[cryptoName:"DateTimeBought"];
        //    return retModel;
        //}

        public void Add(Crypto model)
        {
            //collec.InsertOneAsync(document);
            //return model;
            cryptoList.Add(model);
        }

        public void Remove(PortfolioRemoveModel model)
        {
            var crypto = cryptoList.SingleOrDefault(x => x.Name == model.Name && x.DateTimeBought == model.DateTimeBought);
            if (crypto != null)
                cryptoList.Remove(crypto);
        }

        public IEnumerable<Crypto> GetAll()
        {
            return cryptoList.OrderBy(r => r.DateTimeBought);
        }
    }
}
