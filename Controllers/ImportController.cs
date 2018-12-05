using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ThesisPrototype.ViewModels;

namespace ThesisPrototype.Controllers
{
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

        public IActionResult ImportLocalFile(string filePath)
        {
            using (var fileStream = System.IO.File.OpenRead(filePath))
            {
                _importHandler.Handle(fileStream);
                return Ok();
            }
        }
    }
}
