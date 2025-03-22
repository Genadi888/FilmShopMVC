namespace FilmShopMVC.Repositories
{
    public interface ICartRepository
    {
        Task<int> AddItem(int filmId, int qty);

        Task<int> RemoveItem(int filmId);

        Task<ShoppingCart> GetUserCart();

        Task<int> GetCartItemCount(string userId = "");

        Task<ShoppingCart> GetCart(string userId);

        Task<bool> DoCheckout(CheckoutModel model);
    }
}
