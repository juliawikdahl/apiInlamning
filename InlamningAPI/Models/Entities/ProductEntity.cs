using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InlamningAPI.Models.Entities
{
    public class ProductEntity
    {
        public ProductEntity()
        {
        }

        public ProductEntity(string name, string description, decimal price, int categoryId)
        {
            Name = name;
            Description = description;
            Price = price;
            CategoryId = categoryId;
            Removed = false;
        }

        [Key]
        public int Id { get; set; }


        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(max)")]
        public string Description { get; set; }

        [Required]
        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        public int CategoryId { get; set; }

        public bool Removed { get; set; }

       
    }
}
