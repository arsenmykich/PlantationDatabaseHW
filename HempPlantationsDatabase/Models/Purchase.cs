using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace databaseHempPlantations.Models
{
    public class Purchase
    {
        [Key]
        public int PurchaseID { get; set; }
        public int ConsumerID { get; set; }
        public int AgronomistID { get; set; }
        public int ProductID { get; set; }
        public DateTime PurchaseDate { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
        [ForeignKey("ConsumerID")]
        public virtual Consumer Consumer { get; set; }
        [ForeignKey("AgronomistID")]
        public virtual Agronomist Agronomist { get; set; }
        [ForeignKey("ProductID")]
        public virtual Product Product { get; set; }
    }
}
