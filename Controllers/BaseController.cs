using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ThesisPrototype.DatabaseApis;
using ThesisPrototype.DataModels;

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
            var getUserTask = _userManager.Users
                                          .SingleAsync(u => u.UserName.Equals(HttpContext.User.Identity.Name));
            getUserTask.Wait();
            
            return getUserTask.Result;
        }

        protected ICollection<Ship> GetShipsEntitiesOfCurrentUser()
        {
            var currentUser = GetCurrentUserEntity();
            using (var context = new PrototypeContext())
            {
                var currUser = GetCurrentUserEntity();
                return context.Ships.Where(s => s.UserId == currentUser.UserId).ToList();
            }
        }

        protected bool CurrentUserIsAllowedAccessToShip(long shipId)
        {
            return GetShipsEntitiesOfCurrentUser().Any(s => s.ShipId == shipId);
        }
    }
}