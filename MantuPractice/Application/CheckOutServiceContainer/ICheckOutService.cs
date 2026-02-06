using MantuPractice.Domain.DataTransferObjects;
using MantuPractice.Domain.Models;

namespace MantuPractice.Application.CheckOutServiceContainer
{
    public interface ICheckoutService
    {
        Task<OrderDTO> CheckoutAsync(CheckoutRequest request);
        Task<IEnumerable<OrderDTO>> GetOrdersForUserAsync(int userId);
        Task<OrderDTO> GetOrderByIdAsync(int orderId);
    }

}
