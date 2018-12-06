using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ThesisPrototype.DataModels;

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
