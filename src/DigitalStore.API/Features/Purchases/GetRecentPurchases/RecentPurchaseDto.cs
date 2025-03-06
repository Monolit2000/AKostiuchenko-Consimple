namespace DigitalStore.API.Features.Purchases.GetRecentPurchases
{
    public class RecentPurchaseDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public DateTime LastPurchaseDate { get; set; }
    }
}
