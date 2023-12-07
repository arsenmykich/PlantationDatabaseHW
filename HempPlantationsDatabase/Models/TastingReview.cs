using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace databaseHempPlantations.Models
{
    public class TastingReview
    {
        [Key]
        public int TastingReviewID { get; set; }
        public int TastingID { get; set; }
        public int ReviewID { get; set; }
        [ForeignKey("ReviewID")]
        public virtual Review Review { get; set; }
        [ForeignKey("TastingID")]
        public virtual Tasting Tasting { get; set; }
    }
}
