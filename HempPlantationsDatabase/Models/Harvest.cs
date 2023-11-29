namespace databaseHempPlantations.Models
{
    public class Harvest
    {
        public int HarvestID { get; set; }
        public int AgronomistID { get; set; }
        public int VarietyID { get; set; }
        public DateTime HarvestDate { get; set; }
        public int Quantity { get; set; }
    }
}
