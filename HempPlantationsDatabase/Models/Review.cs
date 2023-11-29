namespace databaseHempPlantations.Models
{
    public class Review
    {
        public int ReviewID { get; set; }
        public int ConsumerID { get; set; }
        public int AgronomistID { get; set; }
        public DateTime ReviewDate { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
    }
}
