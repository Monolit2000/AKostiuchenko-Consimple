namespace DigitalStore.API.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime RegistrationDate { get; set; }
        public List<Purchase> Purchases { get; set; }
    }
}
