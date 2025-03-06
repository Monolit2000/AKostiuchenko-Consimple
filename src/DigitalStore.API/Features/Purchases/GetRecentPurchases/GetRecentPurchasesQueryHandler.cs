using DigitalStore.API.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DigitalStore.API.Features.Purchases.GetRecentPurchases
{
    public class GetRecentPurchasesHandler(
        StoreDbContext storeDbContext) : IRequestHandler<GetRecentPurchasesQuery, List<RecentPurchaseDto>>
    {
        public async Task<List<RecentPurchaseDto>> Handle(GetRecentPurchasesQuery request, CancellationToken cancellationToken)
        {
            var dateLimit = DateTime.UtcNow.AddDays(-request.Days);
            return await storeDbContext.Purchases
                .Where(p => p.Date >= dateLimit)
                .GroupBy(p => p.Client)
                .Select(g => new RecentPurchaseDto
                {
                    Id = g.Key.Id,
                    FullName = g.Key.FullName,
                    LastPurchaseDate = g.Max(p => p.Date)
                })
                .ToListAsync(cancellationToken);
        }
    }
}
