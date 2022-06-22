namespace BespokedBikes.Models
{
    public class Sale
    {
        public int? SaleID { get; set; }
        public int ProductID { get; set; }
        public int SalesPersonID { get; set; }
        public int CustomerID { get; set; }
        public String SalesDate { get; set; }
    }
}
