using InlamningAPI.Models.Entities;

namespace InlamningAPI.Models
{
    public class OrderUpdateModel
    {
        public OrderUpdateModel(string status, OrderedProductEntity orderedProduct)
        {
            Status = status;
            OrderedProduct = orderedProduct;
        }

        public string Status { get; set; }
        public OrderedProductEntity OrderedProduct { get; set; }
 

    }
}
