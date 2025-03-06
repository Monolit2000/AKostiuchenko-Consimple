namespace DigitalStore.API.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Article { get; set; }
        public decimal Price { get; set; }
        public List<PurchaseItem> PurchaseItems { get; set; }
    }
}
