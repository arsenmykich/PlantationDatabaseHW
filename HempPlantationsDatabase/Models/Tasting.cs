using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace databaseHempPlantations.Models
{
    public class Tasting
    {
        [Key]
        public int TastingID { get; set; }
        public int AgronomistID { get; set; }
        public int ConsumerID { get; set; }
        public int ProductID { get; set; }
        public DateTime TastingDate { get; set; } = DateTime.UtcNow;
        public int Rating { get; set; }

        [ForeignKey("ConsumerID")]
        public virtual Consumer Consumer { get; set; }

        [ForeignKey("AgronomistID")]
        public virtual Agronomist Agronomist { get; set; }

        [ForeignKey("ProductID")]
        public virtual Product Product { get; set; }
    }
}
