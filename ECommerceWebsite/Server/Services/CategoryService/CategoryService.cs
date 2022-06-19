
using ECommerceWebsite.Server.Data;
using ECommerceWebsite.Shared;
using Microsoft.EntityFrameworkCore;

namespace ECommerceWebsite.Server.Services.CategoryService {
    public class CategoryService : ICategoryService {
        private readonly DataContext _context;

        public CategoryService(DataContext context) {
            _context = context;
        }
        public List<Category> Categories { get; set; } = new List<Category> {
            //hardcoding for mocking data without database
                //            new Category {Id=1,Name ="Books",Url="books",Icon="book"},
                //new Category {Id=2,Name ="Electronics",Url="electronics",Icon="camera-slr"},
                //new Category {Id=3,Name ="Video-games",Url="video-games",Icon="aperture"}
        };
        public async Task<List<Category>> GetCategories() {
            //hardcoding
            //return Categories;
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category> GetCategoryByUrl(string categoryUrl) {
            //hardcoding
            // return Categories.FirstOrDefault(c => c.Url.ToLower().Equals(categoryUrl.ToLower()));
            return await _context.Categories.FirstOrDefaultAsync(c => c.Url.ToLower().Equals(categoryUrl.ToLower()));
        }
    }
}
