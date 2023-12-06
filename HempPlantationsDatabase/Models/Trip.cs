namespace databaseHempPlantations.Models
{
    public class Trip
    {
        public int TripID { get; set; }
        public int AgronomistID { get; set; }
        public int HarvestID { get; set; }
        public DateTime TripDate { get; set; }
        public string Destination { get; set; }
        public virtual Harvest Harvesties { get; set; }
        public virtual Agronomist Agronomisties { get; set; }
    }
}
