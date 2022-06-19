using Blazored.LocalStorage;
using Blazored.Toast.Services;
using ECommerceWebsite.Client.Services.ProductService;
using ECommerceWebsite.Shared;

namespace ECommerceWebsite.Client.Services.CartService {
    public class CartService : ICartService {
        private readonly ILocalStorageService _localStorage;
        private readonly IToastService _toastService;
        private readonly IProductService _productService;
        public CartService(ILocalStorageService localStorage, IToastService toastService, IProductService productService) {
            _localStorage = localStorage;
            _toastService = toastService;
            _productService = productService;
        }
        public event Action OnChange;

  
        public async Task AddToCart(ProductVariant productVariant) {
            var cart = await _localStorage.GetItemAsync<List<ProductVariant>>("cart");
            if (cart==null) {
                cart = new List<ProductVariant>();
            }
            cart.Add(productVariant);
            await _localStorage.SetItemAsync("cart", cart);
            var product = await _productService.GetProduct(productVariant.ProductId);
            _toastService.ShowSuccess(product.Title, "Added to cart:");
            OnChange.Invoke();
        }

        public Task AddToCart(CartItemDTO item) {
            throw new NotImplementedException();
        }

        public async Task DeleteItem(CartItemDTO item) {
            var cart = await _localStorage.GetItemAsync<List<ProductVariant>>("cart");
            if (cart == null) {
                return;
            }
            var cartItem = cart.Find(x => x.ProductId == item.ProductId && x.EditionId == item.EditionId);
            //composite primary key
            cart.Remove(cartItem);
            await _localStorage.SetItemAsync("cart", cart);
            OnChange.Invoke();
        }

        public Task EmptyCart() {
            throw new NotImplementedException();
        }

        public async Task<List<CartItemDTO>> GetCartItems() {
            var result=new List<CartItemDTO>();
            var cart = await _localStorage.GetItemAsync<List<ProductVariant>>("cart");
            if (cart==null) {
                return result;
            }
            foreach (var item in cart) {
                var product = await _productService.GetProduct(item.ProductId);
                var cartItem = new CartItemDTO {
                    ProductId = product.Id,
                    ProductTitle = product.Title,
                    Image = product.Image,
                    EditionId = item.EditionId
                };
                var variant = product.Variants.Find(v => v.EditionId == item.EditionId);
                if (variant!=null) {
                    cartItem.EditionName = variant.Edition?.Name; //Check Edition wehather null, if not null, access name.
                    cartItem.Price = variant.Price;
                    /* DEFINE VARIANTS AND EDITION ON API PRODUCTSERVICE->GETPRODUCT, THAT IS WHY WE CAN ACCESS VARIANTS AND EDITION ON HERE.
                Product product = await _context.Products
                .Include(p=>p.Variants)
                .ThenInclude(variant=>variant.Edition)
                .FirstOrDefaultAsync(p => p.Id == id);
            return product;
                     */
                }
                result.Add(cartItem);
            }
            return result;
        }
    }
}
