using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InlamningAPI.Models.Entities
{
    public class OrderEntity
    {
      
        public OrderEntity(int customerId)
        {
            OrderDate = DateTime.Now;
            Status = "Påbörjad";
            CustomerId = customerId;
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "datetime2")]
        public DateTime OrderDate { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string Status { get; set; }
       
        [Required]
        public int CustomerId { get; set; }

        
    }
}
