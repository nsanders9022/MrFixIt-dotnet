﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MrFixIt.Controllers
{
    public class AboutController : Controller
    {
        // Displays about page
        public IActionResult Index()
        {
            return View();
        }
    }
}
