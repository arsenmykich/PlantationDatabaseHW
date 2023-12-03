namespace databaseHempPlantations.Models
{
    public class Purchase
    {    
        public int PurchaseID { get; set; }
        public int ConsumerID { get; set; }
        public int AgronomistID { get; set; }
        public int ProductID { get; set; }
        public DateTime PurchaseDate { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
        public virtual Consumer Consumeries { get; set; }
        public virtual Agronomist Agronomisties { get; set; }
        public virtual Product Producties { get; set; }
    }
}
