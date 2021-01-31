using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalaryCalculator.Models;

namespace SalaryCalculator.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View(new salary());
        }

        [HttpPost]

        public IActionResult Index(salary pay)
        {
            if(pay.sal > 50000)
            {
                pay.tax = pay.sal * 10 / 100;
            }
            else if(pay.sal > 30000)
            {
                pay.tax = pay.sal * 5 / 100;
            }
            else
            {
                pay.tax = 0;
            }

            pay.net = pay.sal - pay.tax;

            return View(pay);
        }

       
        

 

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
