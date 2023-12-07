using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace databaseHempPlantations.Models
{
    public class Return
    {
        [Key]
        public int ReturnID { get; set; }
        public int ConsumerID { get; set; }
        public int AgronomistID { get; set; }
        public int ProductID { get; set; }
        public DateTime ReturnDate { get; set; } = DateTime.UtcNow;
        public int Quantity { get; set; }

        [ForeignKey("ConsumerID")]
        public virtual Consumer Consumer { get; set; }

        [ForeignKey("AgronomistID")]
        public virtual Agronomist Agronomist { get; set; }

        [ForeignKey("ProductID")]
        public virtual Product Product { get; set; }
    }
}
