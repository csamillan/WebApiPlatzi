using Microsoft.AspNetCore.Mvc;
using WebApi.Service;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HelloWorldController : ControllerBase
    {

        IHelloWorldService helloWorldService;

        public HelloWorldController(IHelloWorldService helloWorldId)
        {
            helloWorldService = helloWorldId;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(helloWorldService.GetHelloWorld());
        }
    }
}
