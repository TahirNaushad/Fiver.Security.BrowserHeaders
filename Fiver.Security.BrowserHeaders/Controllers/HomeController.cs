﻿using Microsoft.AspNetCore.Mvc;

namespace Fiver.Security.BrowserHeaders.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
