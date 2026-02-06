using MantuPractice.Domain.DataTransferObjects;
using MantuPractice.Domain.Models;

namespace MantuPractice.Application.CartServiceContainer
{
    public interface ICartService
    {
        Task<CartDto> GetCartByIdAsync(int cartId);
        Task<CartDto> GetCartForUserAsync(int userId);
        Task<CartDto> AddItemAsync(AddCartItemRequest req);
        Task<CartDto> UpdateItemAsync(int cartItemId, int quantity);
        Task RemoveItemAsync(int cartItemId);
        Task ClearCartAsync(int cartId);
    }

}
