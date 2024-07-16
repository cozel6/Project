using Microsoft.AspNetCore.Mvc;
using Store.Models;
using Store.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Store.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private ICategoryService service;

        public CategoriesController(ICategoryService service)
        {
            this.service = service;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var categories = service.GetAll();

            return Ok(categories);
        }

        [HttpPost]
        public IActionResult Create(CategoryModel categoryModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var category = service.Add(categoryModel);

            return CreatedAtAction(nameof(GetAll), new { id = category.Categoryid }, category);
        }

        // GET api/<CategoriesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // PUT api/<CategoriesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            
        }

        // DELETE api/<CategoriesController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            //to do call service
            service.Delete(id);
            return Ok();
        }
    }
}
