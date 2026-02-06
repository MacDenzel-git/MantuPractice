namespace MantuPractice.Domain.DataTransferObjects
{
    public class CartSummaryDTO
    {

        public List<CartLineDTO> Lines { get; set; } = new();
        public decimal Total { get; set; }
    }
}

