using Microsoft.AspNetCore.Mvc;
using WebApi.Model;
using WebApi.Service;

namespace WebApi.Controllers
{
    [Route("api/[Controller]")]
    public class CategoryController : ControllerBase
    {

        ICategoryService categoryService;

        public CategoryController(ICategoryService Service)
        {
            categoryService = Service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(categoryService.Get());
        }

        [HttpPost]
        public IActionResult Post([FromBody] Category category)
        {
            categoryService.Save(category);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] Category category)
        {
            categoryService.Update(id,category);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            categoryService.Delete(id);
            return Ok();
        }
    }
}
