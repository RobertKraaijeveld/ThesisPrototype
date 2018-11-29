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
            if(Request.Form.Files.Any() && Request.Form.Files.Count() == 1)
            {
                var file = Request.Form.Files.First();
                _importHandler.SaveImportAndReturnRows(file);

                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
