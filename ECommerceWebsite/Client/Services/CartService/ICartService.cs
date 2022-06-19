using ECommerceWebsite.Shared;

namespace ECommerceWebsite.Client.Services.CartService {
    public interface ICartService {
        event Action OnChange;
        Task AddToCart(ProductVariant productVariant);
        Task AddToCart(CartItemDTO item);
        Task<List<CartItemDTO>> GetCartItems();
        Task DeleteItem(CartItemDTO item);
        Task EmptyCart();
    }
}
