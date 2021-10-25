namespace SimpleRegister.Application.Models
{
    public class UserModel
    {
        public string Email { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        public bool EmailConfirmed { get; set; }
    }
}
