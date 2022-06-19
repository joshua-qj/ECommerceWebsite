using ECommerceWebsite.Shared;

namespace ECommerceWebsite.Client.Services.CategoryService {
    public interface ICategoryService {
        List<Category> Categories { get; set; }
        Task LoadCategories();
        List<Category> AdminCategories { get; set; }
        Task GetCategories();
        Task GetAdminCategories();
        Task AddCategory(Category category);
        Task UpdateCategory(Category category);
        Task DeleteCategory(int categoryId);
        Category CreateNewCategory();
    }
}
