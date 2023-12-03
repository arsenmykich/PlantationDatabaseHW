namespace databaseHempPlantations.Models
{
    public class HarvestProduct
    {
        public int HarvestProductID { get; set; }
        public int HarvestID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public virtual Product Producties { get; set; }
        public virtual Harvest Harvesties { get; set; }
    }
}
