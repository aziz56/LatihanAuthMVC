using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWebFormApp.BLL.Interfaces;
using MyWebFormApp.BLL.DTOs;

namespace LatWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryBLL _categoryBLL;
        public CategoriesController(ICategoryBLL categoryBLL)
        {
            _categoryBLL = categoryBLL;
        }
        [HttpGet]
        public IEnumerable<CategoryDTO> Get()
        {
            return _categoryBLL.GetAll();
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var category = _categoryBLL.GetById(id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }
        [HttpPost]

        public IActionResult Post(CategoryCreateDTO category)
        {
            _categoryBLL.Insert(category);
            return CreatedAtAction(nameof(Get), new { id = category.CategoryName }, category);
        
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, CategoryUpdateDTO category)
        {
            if (id != category.CategoryID)
            {
                return BadRequest();
            }
            _categoryBLL.Update(category);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete (int id)
        {
            _categoryBLL.Delete(id);
            return NoContent();
        }
  



    }
}
