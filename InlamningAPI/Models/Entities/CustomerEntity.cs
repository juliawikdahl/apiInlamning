using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InlamningAPI.Models.Entities
{
    [Index(nameof(Email), IsUnique = true)]
    public class CustomerEntity
      
    {
        public CustomerEntity()
        {
        }

        public CustomerEntity(string firstName, string lastName, string email, string password)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
        }

        public CustomerEntity(string firstName, string lastName, string email, string address, string city, string postalCode)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Address = address;
            City = city;
            PostalCode = postalCode;
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string FirstName { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string LastName { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Email { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Password { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string Address { get; set; }


        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string City { get; set; }


        [Required]
        [Column(TypeName = "char(5)")]
        public string PostalCode { get; set; }
    }
}
