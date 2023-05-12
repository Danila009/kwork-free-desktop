namespace FreeWPF.data.api.model
{
    internal class RegistrationBody
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public int SpecializationId { get; set; }
    }
}
