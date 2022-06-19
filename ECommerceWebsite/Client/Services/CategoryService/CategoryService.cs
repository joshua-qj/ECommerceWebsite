using ECommerceWebsite.Shared;
using System.Net.Http.Json;

namespace ECommerceWebsite.Client.Services.CategoryService {
    public class CategoryService : ICategoryService {
        private readonly HttpClient _http;

        public List<Category> Categories { get;set; }=new List<Category>();
        public CategoryService(HttpClient http) {
            _http = http;
        }
        public async Task LoadCategories() {
            Categories = await _http.GetFromJsonAsync<List<Category>>("api/Category");
                
                //new List<Category> {
                //new Category {Id=1,Name ="Books",Url="books",Icon="book"},
                //new Category {Id=2,Name ="Electronics",Url="electronics",Icon="camera-slr"},
                //new Category {Id=3,Name ="Video-games",Url="video-games",Icon="aperture"}
            
        }
        public List<Category> AdminCategories { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Task AddCategory(Category category) {
            throw new NotImplementedException();
        }

        public Category CreateNewCategory() {
            throw new NotImplementedException();
        }

        public Task DeleteCategory(int categoryId) {
            throw new NotImplementedException();
        }

        public Task GetAdminCategories() {
            throw new NotImplementedException();
        }

        public Task GetCategories() {
            throw new NotImplementedException();
        }

        public Task UpdateCategory(Category category) {
            throw new NotImplementedException();
        }
    }
}
