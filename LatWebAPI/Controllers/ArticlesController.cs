using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWebFormApp.BLL.Interfaces;
using MyWebFormApp.BLL.DTOs;
using MyWebFormApp.BLL;
namespace LatWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        private readonly IArticleBLL _articleBLL;
        public ArticlesController(IArticleBLL articleBLL)
        {
            _articleBLL = articleBLL;
        }
        [HttpGet]
        public IEnumerable<ArticleDTO> Get()
        {
            return _articleBLL.GetArticleWithCategory();   
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var article = _articleBLL.GetArticleById(id);
            if (article == null)
            {
                return NotFound();
            }
            return Ok(article);
        }
        [HttpPost]
        public IActionResult Post(ArticleCreateDTO article)
        {
            _articleBLL.Insert(article);
            return CreatedAtAction(nameof(Get), new { id = article.Title }, article);
        }
        [HttpPut]
        public IActionResult Put(int id, ArticleUpdateDTO article)
        {
            if (id != article.ArticleID)
            {
                return BadRequest();
            }
            _articleBLL.Update(article);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _articleBLL.Delete(id);
            return NoContent();
        }

    }
}
