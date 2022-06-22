namespace BespokedBikes.Models
{
    public class Product
    {
        public int? ProductID { get; set; }
        public String ProductName { get; set; }
        public String Manufacturer { get; set; }
        public String Style { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal SalePrice { get; set; }

        public int QtyOnHand { get; set; }
        public int CommisionPercentage { get; set; }

    }
}
