using AutoMapper;
using MantuPractice.Domain.DataTransferObjects;
using MantuPractice.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace MantuPractice.Application.CheckOutServiceContainer
{
    public class OrderService : ICheckoutService
    {
        private readonly BdeComDbContext _db;
        private readonly IMapper _mapper;

        public OrderService(BdeComDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<OrderDTO> CheckoutAsync(CheckoutRequest request)
        {
            using var transaction = await _db.Database.BeginTransactionAsync();

            try
            {
                var cart = await _db.Carts
                    .Include(c => c.Items)
                    .ThenInclude(i => i.Variant)
                    .ThenInclude(v => v.Product)
                    .FirstOrDefaultAsync(c => c.CartId == request.CartId && c.UserId == request.UserId);

                if (cart == null)
                    throw new InvalidOperationException("Cart not found.");

                if (!cart.Items.Any())
                    throw new InvalidOperationException("Cart is empty.");

                // Create Order
                var order = new Order
                {
                    UserId = request.UserId,
                    OrderDate = DateTime.UtcNow,
                    Status = "Pending"
                };

                decimal total = 0;

                foreach (var item in cart.Items)
                {
                    // Lock in price snapshot
                    var price = item.UnitPrice;

                    var orderItem = new OrderItem
                    {
                        VariantId = item.VariantId,
                        Quantity = item.Quantity,
                        UnitPrice = price
                    };

                    total += price * item.Quantity;
                    order.OrderItems.Add(orderItem);
                }

                order.TotalAmount = total;

                _db.Orders.Add(order);

                // Optional: update stock
                //foreach (var item in cart.Items)
                //{
                //    item.Variant.StockQuantity -= item.Quantity;
                //}

                // Clear cart
                _db.CartItems.RemoveRange(cart.Items);

                await _db.SaveChangesAsync();
                await transaction.CommitAsync();

                return _mapper.Map<OrderDTO>(order);
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task<IEnumerable<OrderDTO>> GetOrdersForUserAsync(int userId)
        {
            var orders = await _db.Orders
                .Include(o => o.OrderItems)
                .ThenInclude(i => i.Variant)
                .ThenInclude(v => v.Product)
                .Where(o => o.UserId == userId)
                .OrderByDescending(o => o.OrderDate)
                .ToListAsync();

            return _mapper.Map<IEnumerable<OrderDTO>>(orders);
        }

        public async Task<OrderDTO> GetOrderByIdAsync(int orderId)
        {
            var order = await _db.Orders
                .Include(o => o.OrderItems)
                .ThenInclude(i => i.Variant)
                .ThenInclude(v => v.Product)
                .FirstOrDefaultAsync(o => o.OrderId == orderId);

            return _mapper.Map<OrderDTO>(order);
        }
    }

}
