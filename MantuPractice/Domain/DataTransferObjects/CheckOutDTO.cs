namespace MantuPractice.Domain.DataTransferObjects
{
    public class CheckoutRequest
    {
        public int UserId { get; set; }
        public int CartId { get; set; }
        public string PaymentMethod { get; set; } = "Manual"; // later: PayPal, Card, etc.
        public string? ShippingAddress { get; set; }
    }

    public class CheckoutItemDTO
    {
        public int ProductId { get; set; }
        public int Qty { get; set; }
    }

}
