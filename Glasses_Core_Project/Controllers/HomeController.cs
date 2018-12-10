using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Glasses_Core_Project.Models;

namespace Glasses_Core_Project.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Home()
        {
            return View();
        }            
    }
}
