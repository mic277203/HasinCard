﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HasinCard.MVC.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class CategorysController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}