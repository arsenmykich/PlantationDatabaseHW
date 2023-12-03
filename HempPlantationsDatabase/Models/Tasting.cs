namespace databaseHempPlantations.Models
{
    public class Tasting
    {
        public int TastingID { get; set; }
        public int AgronomistID { get; set; }
        public int ConsumerID { get; set; }
        public int ProductID { get; set; }
        public DateTime TastingDate { get; set; }
        public int Rating { get; set; }

        public virtual Consumer Consumeries { get; set; }
        public virtual Agronomist Agronomisties { get; set; }
        public virtual Product Producties { get; set; }
    }
}
