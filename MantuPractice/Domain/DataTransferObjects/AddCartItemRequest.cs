namespace MantuPractice.Domain.DataTransferObjects
{
    public class AddCartItemRequest
    {
        public int? CartId { get; set; }    // optional, if you pass a cartId for anonymous cart
        public int? UserId { get; set; }    // optional: if user logged-in
        public int VariantId { get; set; }
        public int Quantity { get; set; }
    }
}
