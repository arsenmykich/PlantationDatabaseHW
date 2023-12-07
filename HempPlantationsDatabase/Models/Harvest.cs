using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace databaseHempPlantations.Models
{
    public class Harvest
    {
        [Key]
        public int HarvestID { get; set; }
        public int AgronomistID { get; set; }
        public int VarietyID { get; set; }
        public DateTime HarvestDate { get; set; } = DateTime.UtcNow;
        public int Quantity { get; set; }
        [ForeignKey("VarietyID")]
        public virtual HempVariety HempVariety { get; set; }
        [ForeignKey("AgronomistID")]
        public virtual Agronomist Agronomist { get; set; }
    }
}
