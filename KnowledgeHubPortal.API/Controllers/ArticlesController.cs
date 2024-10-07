using KnowledgeHubPortal.Domain.Entities;
using KnowledgeHubPortal.Domain.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KnowledgeHubPortal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        private readonly IArticleRepository _article = null;

        public ArticlesController(IArticleRepository article)
        {
            _article = article;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            return Ok(await _article.GetArticlesAsync());
        }

        [HttpGet]
        [Route("{categoryId:int}")]
        public async Task<IActionResult> GetArticlesForSave(int categoryId)
        {
            return Ok(await _article.GetArticlesForSaveAsync(categoryId));
        }

        [HttpGet]
        [Route("review/{categoryId:int}")]
        public async Task<IActionResult> GetArticlesForReview(int categoryId)
        {
            return Ok(await _article.GetArticlesForReviewAsync(categoryId));
        }

        [HttpPut]
        [Route("approve")]
        public async Task<IActionResult> ArticlesForApprove([FromBody]List<int> categoryId)
        {
            if (categoryId.Count <= 0 || categoryId == null || categoryId.Contains(0))
            {
                return BadRequest(categoryId);
            }
             await  _article.ApproveArticleAsync(categoryId);
            return Ok();
        }

        [HttpDelete]
        [Route("reject")]
        public async Task<IActionResult> ArticlesForReject([FromBody] List<int> categoryId)
        {
            if (categoryId.Count <= 0 || categoryId == null || categoryId.Contains(0))
            { 
                return BadRequest(categoryId);
            }
            await _article.RejectArticleAsync(categoryId);
            return Ok();
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateArticles([FromBody] Article article)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _article.AddArticleAsync(article);
            return Created($"api/articles/{article.ArticleID}", article);
        }
    }
}
