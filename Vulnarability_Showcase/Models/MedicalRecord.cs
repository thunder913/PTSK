namespace Vulnarability_Showcase.Models
{
    public class MedicalRecord
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public DateTime CreatedOn { get; set; }
        public string GPName { get; set; }
    }
}
