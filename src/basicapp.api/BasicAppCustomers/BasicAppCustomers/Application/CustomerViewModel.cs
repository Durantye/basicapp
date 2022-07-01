namespace BasicAppCustomers.Application
{
    public class CustomerViewModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public CustomerViewModel(string name, string email, string phone)
        {
            Name = name;
            Email = email;
            Phone = phone;
        }
    }
}