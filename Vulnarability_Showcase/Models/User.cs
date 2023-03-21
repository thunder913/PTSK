namespace Vulnarability_Showcase.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EGN { get; set; }
        public string Address { get; set; }
        public MedicalRecord MedicalRecord { get; set; }
    }
}
