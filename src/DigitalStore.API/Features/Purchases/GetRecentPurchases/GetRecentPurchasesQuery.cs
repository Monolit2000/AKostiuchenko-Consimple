using MediatR;

namespace DigitalStore.API.Features.Purchases.GetRecentPurchases
{
    public record GetRecentPurchasesQuery(int Days) : IRequest<List<RecentPurchaseDto>>;
}
