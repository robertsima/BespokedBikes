namespace BespokedBikes.Models
{
    public class Discount
    {
        public int? DiscountID { get; set; }
        public String ProductID { get; set; }

        public String BeginDate { get; set; }
        public String EndDate { get; set; }
        public int DiscountPercentage { get; set; }
    }
}
