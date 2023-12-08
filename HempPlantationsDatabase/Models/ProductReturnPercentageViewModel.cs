namespace HempPlantationsDatabase.Models
{
    public class ProductReturnPercentageViewModel
    {
        public int ProductID { get; set; }
        public int CustomerCount { get; set; }
        public int ReturnCustomerCount { get; set; }
        public double ReturnPercentage { get; set; }
    }

}
