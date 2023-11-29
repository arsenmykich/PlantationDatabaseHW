namespace databaseHempPlantations.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.ComponentModel.DataAnnotations;
    public class HempVariety
    {
        [Key]
        public int VarietyID { get; set; }
        public string VarietyName { get; set; }
        public string Description { get; set; }
    }
}
