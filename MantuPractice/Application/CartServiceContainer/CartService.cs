using AutoMapper;
using MantuPractice.Domain.DataTransferObjects;
using MantuPractice.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace MantuPractice.Application.CartServiceContainer
{
    public class CartService : ICartService
    {
        private readonly BdeComDbContext _db;
        private readonly IMapper _mapper;

        public CartService(BdeComDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<CartDto> GetCartByIdAsync(int cartId)
        {
            var cart = await _db.Carts
                .Include(c => c.Items).ThenInclude(i => i.Variant).ThenInclude(v => v.Product)
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.CartId == cartId);

            if (cart == null) return null!; // or throw NotFound
            return _mapper.Map<CartDto>(cart);
        }

        public async Task<CartDto> GetCartForUserAsync(int userId)
        {
            var cart = await _db.Carts
                .Include(c => c.Items).ThenInclude(i => i.Variant).ThenInclude(v => v.Product)
                .Where(c => c.UserId == userId)
                .OrderByDescending(c => c.LastUpdatedAt ?? c.CreatedAt)
                .FirstOrDefaultAsync();

            if (cart == null)
            {
                // optional: create a cart for user
                cart = new Cart { UserId = userId, CreatedAt = DateTime.UtcNow };
                _db.Carts.Add(cart);
                await _db.SaveChangesAsync();
            }

            return _mapper.Map<CartDto>(cart);
        }

        public async Task<CartDto> AddItemAsync(AddCartItemRequest req)
        {
            // get or create cart
            Cart cart;
            if (req.CartId.HasValue)
            {
                cart = await _db.Carts
                    .Include(c => c.Items)
                    .FirstOrDefaultAsync(c => c.CartId == req.CartId.Value)
                    ?? throw new InvalidOperationException("Cart not found");
            }
            else if (req.UserId.HasValue)
            {
                cart = await _db.Carts
                    .Include(c => c.Items)
                    .FirstOrDefaultAsync(c => c.UserId == req.UserId.Value);

                if (cart == null)
                {
                    cart = new Cart { UserId = req.UserId, CreatedAt = DateTime.UtcNow };
                    _db.Carts.Add(cart);
                    await _db.SaveChangesAsync();
                    // reload items
                    cart = await _db.Carts.Include(c => c.Items).FirstAsync(c => c.CartId == cart.CartId);
                }
            }
            else
            {
                // anonymous cart creation
                cart = new Cart { CreatedAt = DateTime.UtcNow };
                _db.Carts.Add(cart);
                await _db.SaveChangesAsync();
            }

            // find variant
            var variant = await _db.ProductVariants.Include(v => v.Product).FirstOrDefaultAsync(v => v.VariantId == req.VariantId);
            if (variant == null) throw new InvalidOperationException("Variant not found");

            // fetch existing item
            var existing = cart.Items.FirstOrDefault(i => i.VariantId == req.VariantId);

            if (existing != null)
            {
                existing.Quantity += req.Quantity;
                existing.UnitPrice = variant.Price ?? variant.Product.Price;
                existing.AddedAt = DateTime.UtcNow;
                _db.CartItems.Update(existing);
            }
            else
            {
                var newItem = new CartItem
                {
                    CartId = cart.CartId,
                    VariantId = req.VariantId,
                    Quantity = req.Quantity,
                    UnitPrice = variant.Price ?? variant.Product.Price,
                    AddedAt = DateTime.UtcNow
                };
                _db.CartItems.Add(newItem);
            }

            cart.LastUpdatedAt = DateTime.UtcNow;
            await _db.SaveChangesAsync();

            // return cart dto
            return await GetCartByIdAsync(cart.CartId);
        }

        public async Task<CartDto> UpdateItemAsync(int cartItemId, int quantity)
        {
            var item = await _db.CartItems
                .Include(i => i.Cart)
                .Include(i => i.Variant).ThenInclude(v => v.Product)
                .FirstOrDefaultAsync(i => i.CartItemId == cartItemId);

            if (item == null) throw new InvalidOperationException("Cart item not found");

            if (quantity <= 0)
            {
                _db.CartItems.Remove(item);
            }
            else
            {
                item.Quantity = quantity;
                _db.CartItems.Update(item);
            }

            item.Cart.LastUpdatedAt = DateTime.UtcNow;
            await _db.SaveChangesAsync();

            return _mapper.Map<CartDto>(item.Cart);
        }

        public async Task RemoveItemAsync(int cartItemId)
        {
            var item = await _db.CartItems.Include(i => i.Cart).FirstOrDefaultAsync(i => i.CartItemId == cartItemId);
            if (item == null) return; // idempotent

            _db.CartItems.Remove(item);
            item.Cart.LastUpdatedAt = DateTime.UtcNow;
            await _db.SaveChangesAsync();
        }

        public async Task ClearCartAsync(int cartId)
        {
            var cart = await _db.Carts.Include(c => c.Items).FirstOrDefaultAsync(c => c.CartId == cartId);
            if (cart == null) return;

            _db.CartItems.RemoveRange(cart.Items);
            cart.LastUpdatedAt = DateTime.UtcNow;
            await _db.SaveChangesAsync();
        }
    }


}
