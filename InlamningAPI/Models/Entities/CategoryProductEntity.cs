using System.ComponentModel.DataAnnotations;

namespace InlamningAPI.Models.Entities
{
    public class CategoryProductEntity
    {
        public CategoryProductEntity(int id, string categoryName)
        {
            Id = id;
            CategoryName = categoryName;
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string CategoryName { get; set; }

    }
}
