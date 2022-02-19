using InlamningAPI.Models.Entities;

namespace InlamningAPI.Models
{
    public class OrderModel
    {
        public OrderModel()
        {
        }

        public OrderModel(int id, DateTime orderDate, string status, int customerId, List<OrderedProducts> products)
        {
            Id = id;
            OrderDate = orderDate;
            Status = status;
            CustomerId = customerId;
            Products = products;
        }

        public OrderModel(int id, DateTime orderDate, string status, int customerId, List<OrderedProducts> products, double totalPrice)
        {
            Id = id;
            OrderDate = orderDate;
            Status = status;
            CustomerId = customerId;
            Products = products;
            TotalPrice = totalPrice;
        }

        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public string Status { get; set; }
        public int CustomerId { get; set; }

        public List<OrderedProducts> Products { get; set; }

        public double TotalPrice { get; set; }

    }
}
