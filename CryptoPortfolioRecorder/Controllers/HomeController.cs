using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CryptoPortfolioRecorder.Data;
using CryptoPortfolioRecorder.Models;
using CryptoPortfolioRecorder.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CryptoPortfolioRecorder.Controllers
{
    public class HomeController : Controller
    {

       private ICryptoDatabase cryptoDataModel;

        public HomeController(ICryptoDatabase cryptoData)
        {
            cryptoDataModel = cryptoData;
        }


        public IActionResult Index()
        {
            return View();
        }
    }
}
