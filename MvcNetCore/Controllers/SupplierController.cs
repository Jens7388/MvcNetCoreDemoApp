﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

namespace MvcNetCore.Controllers
{
    public class SupplierController: Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
