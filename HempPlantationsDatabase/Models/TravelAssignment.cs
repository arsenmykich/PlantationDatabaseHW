namespace databaseHempPlantations.Models
{
    public class TravelAssignment
    {
        public int TravelAssignmentID { get; set; }
        public int AgronomistID { get; set; }
        public int TripID { get; set; }
        public virtual Trip Tripies { get; set; }
        public virtual Agronomist Agronomisties { get; set; }
    }
}
