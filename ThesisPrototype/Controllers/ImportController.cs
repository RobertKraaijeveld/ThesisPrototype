using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ThesisPrototype.DataModels;
using ThesisPrototype.Handlers;

namespace ThesisPrototype.Controllers
{
    public class ImportController : BaseController
    {
        private readonly RedisImportHandler _redisImportHandler;
        private readonly EntityFrameworkImportHandler _entityFrameworkImportHandler;

        public ImportController(RedisImportHandler redisImportHandler, 
                                EntityFrameworkImportHandler entityFrameworkImportHandler, 
                                UserManager<User> userManager) : base(userManager) 
        {
            _redisImportHandler = redisImportHandler;
            _entityFrameworkImportHandler = entityFrameworkImportHandler;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ImportLocalFile(string filePath)
        {
            using (var fileStream = System.IO.File.OpenRead(filePath))
            {
                _redisImportHandler.Handle(fileStream, calculateKpis: false);
            }

            using (var fileStream = System.IO.File.OpenRead(filePath))
            {
                _entityFrameworkImportHandler.Handle(fileStream, calculateKpis: false);
            }
            
            return Ok();
        }
    }
}
