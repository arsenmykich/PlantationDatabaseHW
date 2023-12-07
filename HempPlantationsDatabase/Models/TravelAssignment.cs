using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace databaseHempPlantations.Models
{
    public class TravelAssignment
    {
        [Key]
        public int TravelAssignmentID { get; set; }
        public int AgronomistID { get; set; }
        public int TripID { get; set; }
        [ForeignKey("TripID")]
        public virtual Trip Trip { get; set; }
        [ForeignKey("AgronomistID")]
        public virtual Agronomist Agronomist { get; set; }
    }
}
