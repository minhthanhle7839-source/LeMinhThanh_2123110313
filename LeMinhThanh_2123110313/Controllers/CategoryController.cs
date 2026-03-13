using Microsoft.AspNetCore.Mvc;
using LeMinhThanh_2123110313.Models;

namespace LeMinhThanh_2123110313.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {

        // dữ liệu giả
        private static List<Category> categories = new List<Category>
        {
            new Category { Id = 1, Name = "Laptop", Description = "Laptop products" },
            new Category { Id = 2, Name = "Phone", Description = "Mobile phones" },
            new Category { Id = 3, Name = "Accessory", Description = "Accessories" }
        };

        // GET: api/category
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(categories);
        }

        // GET api/category/1
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var category = categories.FirstOrDefault(c => c.Id == id);

            if (category == null)
                return NotFound("Category not found");

            return Ok(category);
        }

        // POST api/category
        [HttpPost]
        public IActionResult Post([FromBody] Category category)
        {
            category.Id = categories.Max(c => c.Id) + 1;
            categories.Add(category);

            return Ok(category);
        }

        // PUT api/category/1
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Category updatedCategory)
        {
            var category = categories.FirstOrDefault(c => c.Id == id);

            if (category == null)
                return NotFound("Category not found");

            category.Name = updatedCategory.Name;
            category.Description = updatedCategory.Description;

            return Ok(category);
        }

        // DELETE api/category/1
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var category = categories.FirstOrDefault(c => c.Id == id);

            if (category == null)
                return NotFound("Category not found");

            categories.Remove(category);

            return Ok("Deleted successfully");
        }
    }
}