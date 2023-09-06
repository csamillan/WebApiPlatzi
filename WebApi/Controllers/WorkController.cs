using Microsoft.AspNetCore.Mvc;
using WebApi.Model;
using WebApi.Service;

namespace WebApi.Controllers
{
    [Route("api/[Controller]")]
    public class WorkController : ControllerBase
    {
        IWorkService workService;

        public WorkController(IWorkService Service)
        {
            workService = Service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(workService.Get());
        }

        [HttpPost]
        public IActionResult Post([FromBody] Work Work)
        {
            workService.Save(Work);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] Work Work)
        {
            workService.Update(id, Work);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            workService.Delete(id);
            return Ok();
        }
    }
}
