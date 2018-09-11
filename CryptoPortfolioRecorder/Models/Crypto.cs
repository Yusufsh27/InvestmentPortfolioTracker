using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using CryptoPortfolioRecorder.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CryptoPortfolioRecorder.Models
{
    public class Crypto
    {
        [Display(Name = "Crypto Name")]
        [Required, MaxLength(3)]
        public string Name { get; set; }

        [Required]
        public double Amount { get; set; }

        [Required]
        public DateTime DateTimeBought { get; set; }

        [Required]
        public double PriceBought { get; set; }

        public double AmountSpent { get; }

        public double CurrentPrice { get; }

        public double CurrentTotal{ get; }

        public double PercentChange { get; }

        
        public Crypto(string name, double amount, DateTime dateTimeBought, double priceBought)
        {
            dynamic dynJson = SetupCoinMarketCapApi();

            Name = name;
            Amount = amount;
            DateTimeBought = dateTimeBought;
            PriceBought = priceBought;
            AmountSpent = priceBought * amount;
            CurrentPrice = FindPrice(Name, dynJson);
            CurrentTotal = CurrentPrice * amount;
            PercentChange = PortfolioViewModel.CalculateChange(PriceBought, CurrentPrice);
        }

        private dynamic SetupCoinMarketCapApi()
        {
            string listings = "https://api.coinmarketcap.com/v1/ticker/";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(listings);
            WebResponse response = request.GetResponse();
            //Stream responseStream = response.GetResponseStream();
            //StreamReader reader = new StreamReader(responseStream, System.Text.Encoding.UTF8);
            StreamReader reader;
            using (Stream responseStream = response.GetResponseStream())
            {
                reader = new StreamReader(responseStream, System.Text.Encoding.UTF8);
                string rawJson = reader.ReadToEnd();
                dynamic dynJson = JsonConvert.DeserializeObject(rawJson);
                return dynJson;
            }
        }

        private double FindPrice(string name, dynamic dynJson)
        {
            double priceOfCoin = 0;
            foreach (var item in dynJson)
            {
                if (item.symbol == name)
                {
                    priceOfCoin = Convert.ToDouble(item.price_usd);
                }
            }
            return priceOfCoin;
        }

        
    }


    }
