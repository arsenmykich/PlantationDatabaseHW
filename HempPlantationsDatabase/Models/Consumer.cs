using System.ComponentModel.DataAnnotations;

namespace databaseHempPlantations.Models
{
    public class Consumer
    {
        [Key]
        public int ConsumerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string FullName => $"{FirstName} {LastName}";
    }
}
