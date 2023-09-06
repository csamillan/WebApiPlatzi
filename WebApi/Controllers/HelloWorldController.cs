using Microsoft.AspNetCore.Mvc;
using WebApi.Service;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HelloWorldController : ControllerBase
    {
        WorkContext workContext;

        IHelloWorldService helloWorldService;

        public HelloWorldController(IHelloWorldService helloWorldId, WorkContext db)
        {
            helloWorldService = helloWorldId;
            workContext = db;
        }

        [HttpGet]
        [Route("Get")]
        public IActionResult Get()
        {
            return Ok(helloWorldService.GetHelloWorld());
        }

        [HttpGet]
        [Route("CreateDB")]
        public IActionResult CreateDataBase()
        {
            workContext.Database.EnsureCreated();
            return Ok();
        }
    }
}
