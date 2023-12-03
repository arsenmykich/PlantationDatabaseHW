﻿namespace databaseHempPlantations.Models
{
    public class TastingReview
    {
        public int TastingReviewID { get; set; }
        public int TastingID { get; set; }
        public int ReviewID { get; set; }
        public virtual Review Reviewies { get; set; }
        public virtual Tasting Tastingies { get; set; }
    }
}
