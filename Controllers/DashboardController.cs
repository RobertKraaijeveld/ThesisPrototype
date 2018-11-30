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
    [Authorize]
    public class DashboardController : BaseController
    {
        public DashboardController(UserManager<User> userManager) : base(userManager) { }

        public IActionResult Index()
        {
            using(var context = new PrototypeContext())
            {
                var currentUser = base.GetCurrentUserEntity();

                List<VesselViewModel> vesselViewModels = new List<VesselViewModel>(); 
                var vesselsForUser = context.Ships.Include(x => x.User)
                                                    .Where(v => v.UserId == currentUser.UserId)
                                                    .ToList();

                foreach(var vessel in vesselsForUser)
                {
                    vesselViewModels.Add(new VesselViewModel()
                    {
                        ShipName = vessel.Name,
                        ImageName = vessel.ImageName
                    });
                }

                return View(vesselViewModels);
            }
        }
    }
}