using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ThesisPrototype.DataModels;
using ThesisPrototype.Handlers;
using ThesisPrototype.Retrievers;
using ThesisPrototype.ViewModels;

namespace ThesisPrototype.Controllers
{
    [Authorize]
    public class DashboardController : BaseController
    {
        private readonly KpiValueRetriever _kpiValueRetriever;
        private readonly GraphHandler _graphHandler;

        public DashboardController(KpiValueRetriever kpiValueRetriever,
                                   GraphHandler graphHandler, 
                                   UserManager<User> userManager) : base(userManager)
        {
            _kpiValueRetriever = kpiValueRetriever;
            _graphHandler = graphHandler;
        }


        public IActionResult Index()
        {
            using (var context = new PrototypeContext())
            {
                var currentUser = base.GetCurrentUserEntity();

                List<ShipViewModel> shipViewModels = new List<ShipViewModel>();
                var shipsForUser = context.Ships.Include(x => x.User)
                                                  .Where(v => v.UserId == currentUser.UserId)
                                                  .ToList();

                foreach (var vessel in shipsForUser)
                {
                    shipViewModels.Add(new ShipViewModel()
                    {
                        ShipName = vessel.Name,
                        ImageName = vessel.ImageName
                    });
                }

                return View(shipViewModels);
            }
        }

        public IActionResult Details(string shipName)
        {
            using (var context = new PrototypeContext())
            {
                var ship = context.Ships.Single(x => x.Name == shipName);

                var testKpiVals = _kpiValueRetriever.GetSingle(ship.ShipId, EKpi.DailyAveragesKpi1, new DateTime(2000, 1, 1));
                ChartViewModel testGraph = _graphHandler.CreateKpiChartViewModel(titleText: EKpi.DailyAveragesKpi1.ToString(), 
                                                                                 kpiValues: new List<KpiValue>() {testKpiVals});

                return View(testGraph);
            }
        }
    }
}