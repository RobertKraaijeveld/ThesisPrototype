using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ThesisPrototype.ViewModels;

namespace ThesisPrototype.Controllers
{
    [Authorize]
    public class ImportController : BaseController
    {
        private readonly ImportHandler _importHandler;

        public ImportController(ImportHandler importHandler, UserManager<User> userManager) : base(userManager) 
        {
            _importHandler = importHandler;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [RequestSizeLimit(int.MaxValue)]
        [DisableRequestSizeLimit]
        public IActionResult ImportFile()
        {
            var fileCount = Request.Form.Files.Count();

            if (fileCount == 1)
            {
                var file = Request.Form.Files.First();
                _importHandler.Handle(file);

                return View("Index");
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
