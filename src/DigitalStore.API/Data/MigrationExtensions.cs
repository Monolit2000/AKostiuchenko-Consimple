using Microsoft.EntityFrameworkCore;

namespace DigitalStore.API.Data
{
    public static class MigrationExtensions
    {
        public static void ApplyStoreDbMigrations(this IApplicationBuilder app)
        {
            using IServiceScope scope = app.ApplicationServices.CreateScope();

            using StoreDbContext workContext = scope.ServiceProvider.GetRequiredService<StoreDbContext>();

            workContext.Database.Migrate();
        }
    }
}
