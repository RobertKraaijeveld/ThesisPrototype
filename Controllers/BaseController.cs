using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ThesisPrototype.Controllers
{
    public class BaseController : Controller
    {
        public readonly UserManager<User> _userManager;

        protected BaseController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }


        protected User GetCurrentUserEntity()
        {
            var getUserTask = _userManager.GetUserAsync(HttpContext.User);
            getUserTask.Wait();
            
            return getUserTask.Result;
        }
    }
}