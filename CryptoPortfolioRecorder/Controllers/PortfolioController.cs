using CryptoPortfolioRecorder.Data;
using CryptoPortfolioRecorder.Models;
using CryptoPortfolioRecorder.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoPortfolioRecorder.Controllers
{
    public class PortfolioController : Controller
    {
        private ICryptoDatabase cryptoDataModel;

        public PortfolioController(ICryptoDatabase cryptoData)
        {
            cryptoDataModel = cryptoData;
        }

        public IActionResult Index()
        {
            var model = new PortfolioViewModel(cryptoDataModel.GetAll());
            return View(model);
            //return Content("supp my guy");
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(PortfolioAddModel model)
        {
            var newCrypto = new Crypto(model.Name, model.Amount, model.DateTimeBought, model.PriceBought);
            cryptoDataModel.Add(newCrypto);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Remove()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Remove(PortfolioRemoveModel model)
        {
            cryptoDataModel.Remove(model);
            return RedirectToAction(nameof(Index));
        }
    }

    
}
