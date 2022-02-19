using InlamningAPI.Models.Entities;

namespace InlamningAPI.Models
{
    public class CustomerCreateModel
    {
        public CustomerCreateModel(string firstname, string lastname, string email, string password, string address, string city, string postalCode)
        {
            Firstname = firstname;
            Lastname = lastname;
            Email = email;
            Password = password;
            Address = address;
            City = city;
            PostalCode = postalCode;
        }

        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }

    }
}
