using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Tur_agen_asp_net.Models;
using System.Collections;
using Microsoft.EntityFrameworkCore;
using System;

namespace Tur_agen_asp_net.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

      
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        ApDbContext db = new ApDbContext();
        public IActionResult Index()
        {
            ViewBag.ShowTourManagement = true;

             return View(db.Tour.ToList());
           // return View();
        }

         


public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}