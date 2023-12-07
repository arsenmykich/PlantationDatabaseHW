namespace databaseHempPlantations.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class HarvestProduct
    {
        [Key]
        public int HarvestProductID { get; set; }
        public int HarvestID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        [ForeignKey("ProductID")]
        public virtual Product Product { get; set; }
        [ForeignKey("HarvestID")]
        public virtual Harvest Harvest { get; set; }
    }
}
