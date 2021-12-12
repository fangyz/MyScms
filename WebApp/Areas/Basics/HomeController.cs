using BusinessModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Scms.Web.Areas.Base
{

    [Area("Basics")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        //public IActionResult Index()
        //{
        //    return View();
        //}

        public IActionResult Privacy()
        {

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }



        public IActionResult Index()
        {
            ViewBag.Message = "欢迎使用财务模块";

            return View();
        }
        public IActionResult Top()
        {
            ViewBag.UserName = "超级管理员";
            ViewBag.AvailableBalance = "8888.00";
            return View();
        }
        public IActionResult Left()
        {
            return View();
        }
        public IActionResult Right()
        {
            return View();
        }
        public IActionResult Footer()
        {
            return View();
        }
    }
}
