using MantuPractice.Application.CartServiceContainer;
using MantuPractice.Domain.DataTransferObjects;
using MantuPractice.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace MantuPractice.API
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cart;

        public CartController(ICartService cart) => _cart = cart;

        [HttpGet("{cartId}")]
        public async Task<IActionResult> Get(int cartId) => Ok(await _cart.GetCartByIdAsync(cartId));

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetForUser(int userId) => Ok(await _cart.GetCartForUserAsync(userId));

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] AddCartItemRequest req)
        {
            var result = await _cart.AddItemAsync(req);
            return Ok(result);
        }

        [HttpPut("item/{cartItemId}")]
        public async Task<IActionResult> UpdateItem(int cartItemId, [FromBody] int quantity)
        {
            var result = await _cart.UpdateItemAsync(cartItemId, quantity);
            return Ok(result);
        }

        [HttpDelete("item/{cartItemId}")]
        public async Task<IActionResult> RemoveItem(int cartItemId)
        {
            await _cart.RemoveItemAsync(cartItemId);
            return NoContent();
        }

        [HttpDelete("{cartId}/clear")]
        public async Task<IActionResult> Clear(int cartId)
        {
            await _cart.ClearCartAsync(cartId);
            return NoContent();
        }
    }


}
