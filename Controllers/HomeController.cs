using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ThesisPrototype.ViewModels;

namespace ThesisPrototype.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(UserManager<User> userManager) : base(userManager) { }

        public IActionResult Index()
        {
            return View();
        }
    }
}
