using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ThesisPrototype.DataModels;
using ThesisPrototype.Handlers;

namespace ThesisPrototype.Controllers
{
    public class ImportController : BaseController
    {
        private readonly RedisImportHandler _redisImportHandler;

        public ImportController(RedisImportHandler redisImportHandler, UserManager<User> userManager) : base(userManager) 
        {
            _redisImportHandler = redisImportHandler;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ImportLocalFile(string filePath)
        {
            using (var fileStream = System.IO.File.OpenRead(filePath))
            {
                _redisImportHandler.Handle(fileStream);
                return Ok();
            }
        }
    }
}
