namespace InlamningAPI.Models
{
    public class CustomerModel
    {
        public CustomerModel()
        {

        }
        public CustomerModel(string firstname, string lastname, string email, string address, string city, string postalCode)
        {
            Firstname = firstname;
            Lastname = lastname;
            Email = email;
            Address = address;
            City = city;
            PostalCode = postalCode;
        }

        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }

    }
}
