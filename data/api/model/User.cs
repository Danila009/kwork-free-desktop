namespace FreeWPF.data.api.model
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public int Balance { get; set; }
        public int Hourse { get; set; }
        public Specialization Specialization { get; set; } = new();
    }
}
