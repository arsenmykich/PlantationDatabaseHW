using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace databaseHempPlantations.Models
{
    public class Trip
    {
        [Key]
        public int TripID { get; set; }
        public int AgronomistID { get; set; }
        public int HarvestID { get; set; }
        public DateTime TripDate { get; set; } = DateTime.UtcNow;
        public string Destination { get; set; }

        [ForeignKey("HarvestID")]
        public virtual Harvest Harvest { get; set; }

        [ForeignKey("AgronomistID")]
        public virtual Agronomist Agronomist { get; set; }
    }
}
