using System.ComponentModel.DataAnnotations;

namespace databaseHempPlantations.Models
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }

    }
}
