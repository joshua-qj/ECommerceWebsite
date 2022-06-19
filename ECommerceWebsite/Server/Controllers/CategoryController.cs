
using ECommerceWebsite.Server.Services.CategoryService;
using ECommerceWebsite.Shared;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceWebsite.Server.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService) {
            _categoryService = categoryService;
        }

        [HttpGet]
        //[HttpGet("GetCategories")]
         public async Task<ActionResult<List<Category>>> GetCategories() {
            return Ok(await _categoryService.GetCategories());
            //return Ok(new List<Category> {
            //    new Category {Id=1,Name ="Books",Url="books",Icon="book"},
            //    new Category {Id=2,Name ="Electronics",Url="electronics",Icon="camera-slr"},
            //    new Category {Id=3,Name ="Video-games",Url="video-games",Icon="aperture"}
            //});
        }
    }
}
