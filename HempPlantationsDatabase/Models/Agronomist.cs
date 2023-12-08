namespace databaseHempPlantations.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.ComponentModel.DataAnnotations;
    public class Agronomist
    {
        [Key]
        public int AgronomistID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime HireDate { get; set; }
        public string Specialty { get; set; }
        public string FullName => $"{FirstName} {LastName}";
    }
}
