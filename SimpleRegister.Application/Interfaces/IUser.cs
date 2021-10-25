namespace SimpleRegister.Application.Interfaces
{
    public interface IUser
    {
        public string Email { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }
    }
}
