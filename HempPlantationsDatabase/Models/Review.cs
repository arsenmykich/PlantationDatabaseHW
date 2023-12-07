using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace databaseHempPlantations.Models
{
    public class Review
    {
        [Key]
        public int ReviewID { get; set; }
        public int ConsumerID { get; set; }
        public int AgronomistID { get; set; }
        public DateTime ReviewDate { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        [ForeignKey("ConsumerID")]
        public virtual Consumer Consumer { get; set; }
        [ForeignKey("AgronomistID")]
        public virtual Agronomist Agronomist { get; set; }
    }
}
