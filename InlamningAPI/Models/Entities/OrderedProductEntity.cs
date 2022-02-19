namespace InlamningAPI.Models.Entities
{
    public class OrderedProductEntity
    {
        public OrderedProductEntity(int orderId, int productId, int quantity)
        {
            OrderId = orderId;
            ProductId = productId;
            Quantity = quantity;
        }

        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
