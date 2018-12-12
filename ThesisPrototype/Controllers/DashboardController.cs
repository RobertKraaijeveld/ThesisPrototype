using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ThesisPrototype.DatabaseApis;
using ThesisPrototype.DataModels;
using ThesisPrototype.Handlers;
using ThesisPrototype.Retrievers;
using ThesisPrototype.Utilities;
using ThesisPrototype.ViewModels;

namespace ThesisPrototype.Controllers
{
    [Authorize]
    public class DashboardController : BaseController
    {
        private readonly ChartRetriever _chartHandler;

        public DashboardController(ChartRetriever chartHandler,
                                   UserManager<User> userManager) : base(userManager)
        {
            _chartHandler = chartHandler;
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
                    ShipImo = ship.ImoNumber,
                    ShipName = ship.Name,
                    ImageName = ship.ImageName
                });
            }
            return View("Index", shipViewModels);
        }


        #region Individual ship details / Graphs

        public IActionResult Details(long shipId)
        {
            using (var context = new PrototypeContext())
            {
                try
                {
                    if (context.Ships.Any(x => x.ShipId == shipId) && 
                        base.CurrentUserIsAllowedAccessToShip(shipId))
                    {
                        Ship ship = context.Ships.Single(x => x.ShipId == shipId);

                        long defaultChartRangeBeginTs = DateTime.Today.AddMonths(-2).ToUnixMilliTs();
                        long defaultChartRangeEndTs = DateTime.Today.ToUnixMilliTs();

                        List<ChartViewModel> defaultCharts = GetCharts(ship.ShipId,
                                                                        defaultChartRangeBeginTs,
                                                                        defaultChartRangeEndTs);

                        ViewBag.DefaultChartRangeBeginTs = defaultChartRangeBeginTs;
                        ViewBag.DefaultChartRangeEndTs = defaultChartRangeEndTs;
                        ViewBag.ShipName = ship.Name;
                        ViewBag.ShipImo = ship.ImoNumber;
                        ViewBag.ShipId = ship.ShipId;
                        return View(defaultCharts);
                    }
                    else
                    {
                        return Index();
                    }
                }
                catch (Exception e)
                {
                    return Index();
                }
            }
        }

        public List<ChartViewModel> GetCharts(long shipId, long rangeBeginTs, long rangeEndTs)
        {
            return _chartHandler.GetDefaultKpiChartViewModels(shipId, rangeBeginTs.FromUnixMilliTs(), rangeEndTs.FromUnixMilliTs());
        }

        #endregion


        #region Ship CRUD

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

        #endregion
    }
}