
using ContactsList.Server.Model;
using ContactsList.Server.Services.DictionaryService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ContactsList.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DictionaryController : ControllerBase
    {
        private readonly IDictionaryService _dictionaryService;
        public DictionaryController(IDictionaryService dictionaryService)
        {
            _dictionaryService = dictionaryService;
        }

        [HttpGet("Categories")]
        public async Task<ActionResult<List<Category>>> GetCategories()
        {
            var result = await _dictionaryService.GetCategories();

            return Ok(result);
        }

        [HttpGet("Subcategories")]
        public async Task<ActionResult<List<Subcategory>>> GetSubcategories()
        {
            var result = await _dictionaryService.GetSubcategories();

            return Ok(result);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<int>> AddSubcategory(Subcategory subcategory)
        {
            var result = await _dictionaryService.AddSubcategory(subcategory);

            return result == null ? Forbid("Subcategory already exists") : Ok(result.Id);
        }
    }
}
