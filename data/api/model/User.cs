namespace FreeWPF.data.api.model
{
    internal class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public int Balance { get; set; }
    }
}
