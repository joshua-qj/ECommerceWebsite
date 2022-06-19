using ECommerceWebsite.Shared;

namespace ECommerceWebsite.Server.Services.CategoryService {
    public interface ICategoryService {
        Task<List<Category>> GetCategories();
        Task<Category> GetCategoryByUrl(string categoryUrl);
    }
}
