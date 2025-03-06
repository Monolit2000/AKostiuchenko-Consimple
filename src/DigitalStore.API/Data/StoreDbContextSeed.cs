using DigitalStore.API.Data;
using DigitalStore.API.Models;

public static class StoreDbContextSeed
{
    public static async Task SeedAsync(StoreDbContext context)
    {
        if (context.Clients.Any()) return;

        var clients = new List<Client>
        {
            new Client { FullName = "John Smith", BirthDate = new DateTime(1990, 3, 5, 0, 0, 0, DateTimeKind.Utc), RegistrationDate = DateTime.UtcNow.AddMonths(-6) },
            new Client { FullName = "Maria Petrova", BirthDate = new DateTime(1985, 3, 10, 0, 0, 0, DateTimeKind.Utc), RegistrationDate = DateTime.UtcNow.AddMonths(-5) },
            new Client { FullName = "Alex Johnson", BirthDate = new DateTime(1995, 4, 15, 0, 0, 0, DateTimeKind.Utc), RegistrationDate = DateTime.UtcNow.AddMonths(-4) },
            new Client { FullName = "Sophie Brown", BirthDate = new DateTime(1988, 7, 20, 0, 0, 0, DateTimeKind.Utc), RegistrationDate = DateTime.UtcNow.AddMonths(-3) },
            new Client { FullName = "Robert Davis", BirthDate = new DateTime(1992, 12, 25, 0, 0, 0, DateTimeKind.Utc), RegistrationDate = DateTime.UtcNow.AddMonths(-2) }
        };

        var products = new List<Product>
        {
            new Product { Name = "Laptop Dell XPS", Category = "Electronics", Article = "DL123", Price = 1500.00m },
            new Product { Name = "Coffee Lavazza", Category = "Groceries", Article = "CF456", Price = 10.50m },
            new Product { Name = "T-Shirt Adidas", Category = "Clothing", Article = "AD789", Price = 25.00m },
            new Product { Name = "Smartphone Samsung", Category = "Electronics", Article = "SM101", Price = 800.00m },
            new Product { Name = "Chocolate Bar", Category = "Groceries", Article = "CH202", Price = 2.50m },
            new Product { Name = "Sneakers Nike", Category = "Clothing", Article = "NK303", Price = 80.00m }
        };

        var purchases = new List<Purchase>
        {
            new Purchase
            {
                Number = "PUR001",
                Date = DateTime.UtcNow.AddDays(-10),
                Client = clients[0], // John Smith
                Items = new List<PurchaseItem>
                {
                    new PurchaseItem { Product = products[0], Quantity = 1 }, // Laptop
                    new PurchaseItem { Product = products[1], Quantity = 3 }  // Coffee
                }
            },
            new Purchase
            {
                Number = "PUR002",
                Date = DateTime.UtcNow.AddDays(-7),
                Client = clients[1], // Maria Petrova
                Items = new List<PurchaseItem>
                {
                    new PurchaseItem { Product = products[2], Quantity = 2 }, // T-Shirt
                    new PurchaseItem { Product = products[4], Quantity = 5 }  // Chocolate
                }
            },
            new Purchase
            {
                Number = "PUR003",
                Date = DateTime.UtcNow.AddDays(-5),
                Client = clients[2], // Alex Johnson
                Items = new List<PurchaseItem>
                {
                    new PurchaseItem { Product = products[3], Quantity = 1 }, // Smartphone
                    new PurchaseItem { Product = products[5], Quantity = 1 }  // Sneakers
                }
            },
            new Purchase
            {
                Number = "PUR004",
                Date = DateTime.UtcNow.AddDays(-3),
                Client = clients[3], // Sophie Brown
                Items = new List<PurchaseItem>
                {
                    new PurchaseItem { Product = products[1], Quantity = 2 }, // Coffee
                    new PurchaseItem { Product = products[2], Quantity = 1 }  // T-Shirt
                }
            },
            new Purchase
            {
                Number = "PUR005",
                Date = DateTime.UtcNow.AddDays(-1),
                Client = clients[4], // Robert Davis
                Items = new List<PurchaseItem>
                {
                    new PurchaseItem { Product = products[0], Quantity = 1 }, // Laptop
                    new PurchaseItem { Product = products[5], Quantity = 2 }  // Sneakers
                }
            },
            new Purchase
            {
                Number = "PUR006",
                Date = DateTime.UtcNow.AddDays(-2),
                Client = clients[0], // John Smith (second purchase)
                Items = new List<PurchaseItem>
                {
                    new PurchaseItem { Product = products[4], Quantity = 10 }, // Chocolate
                    new PurchaseItem { Product = products[3], Quantity = 1 }   // Smartphone
                }
            }
        };

   
        foreach (var purchase in purchases)
        {
            purchase.TotalAmount = purchase.Items.Sum(i => i.Product.Price * i.Quantity);
        }

     
        await context.Clients.AddRangeAsync(clients);
        await context.Products.AddRangeAsync(products);
        await context.Purchases.AddRangeAsync(purchases);
        await context.SaveChangesAsync();
    }
}