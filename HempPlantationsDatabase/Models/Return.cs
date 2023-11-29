namespace databaseHempPlantations.Models
{
    public class Return
    {
        public int ReturnID { get; set; }
        public int ConsumerID { get; set; }
        public int AgronomistID { get; set; }
        public int ProductID { get; set; }
        public DateTime ReturnDate { get; set; }
        public int Quantity { get; set; }
    }
}
