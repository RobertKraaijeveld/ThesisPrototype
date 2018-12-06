using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ThesisPrototype.DatabaseApis;
using ThesisPrototype.DataModels;
using ThesisPrototype.Handlers;
using ThesisPrototype.Retrievers;
using ThesisPrototype.ViewModels;

namespace ThesisPrototype.Controllers
{
    [Authorize]
    public class DashboardController : BaseController
    {
        private readonly GraphHandler _graphHandler;

        public DashboardController(GraphHandler graphHandler,
                                   UserManager<User> userManager) : base(userManager)
        {
            _graphHandler = graphHandler;
        }


        public IActionResult Index()
        {
            var shipsForUser = base.GetShipsEntitiesOfCurrentUser();
            List<ShipViewModel> shipViewModels = new List<ShipViewModel>();

            foreach (var ship in shipsForUser)
            {
                shipViewModels.Add(new ShipViewModel()
                {
                    ShipId = ship.ShipId,
                    ShipName = ship.Name,
                    ImageName = ship.ImageName
                });
            }
            return View("Index", shipViewModels);
        }

        public IActionResult Details(string shipName)
        {
            using (var context = new PrototypeContext())
            {
                Ship ship = context.Ships.Single(x => x.Name == shipName);

                if (base.CurrentUserIsAllowedAccessToShip(ship.ShipId))
                {
                    List<ChartViewModel> graphs =
                        _graphHandler.GetDefaultKpiChartViewModels(ship.ShipId,
                            rangeBegin: DateTime.Today.AddMonths(-1),
                            rangeEnd: DateTime.Today);

                    return View(graphs);
                }
                else
                {
                    return View("Index");
                }
            }
        }

        public IActionResult GetCreateShipPanelPartial()
        {
            return PartialView("_CreateShipPanelPartial");
        }

        [HttpPost]
        public IActionResult CreateNewShip(ShipCreateViewModel newShipModel)
        {
            try
            {
                using (var context = new PrototypeContext())
                {
                    var shipsUser = base.GetCurrentUserEntity();

                    context.Ships.Add(new Ship()
                    {
                        Name = newShipModel.ShipName,
                        ImageName = newShipModel.ImageName,
                        CountryName = newShipModel.CountryName,
                        ImoNumber = Int32.Parse(newShipModel.ImoNumber),
                        UserId = shipsUser.UserId
                    });
                    context.SaveChanges();

                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", "Something went wrong, please try again.");
            }

            return View("Index");
        }

        [HttpPost]
        public IActionResult DeleteShip(long shipId)
        {
            try
            {
                using (var context = new PrototypeContext())
                {
                    var shipToBeDeleted = context.Ships.Single(s => s.ShipId == shipId);

                    context.Ships.Remove(shipToBeDeleted);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", "Something went wrong, please try again.");
            }

            return Index();
        }
    }
}