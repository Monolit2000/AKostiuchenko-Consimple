using DigitalStore.API.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DigitalStore.API.Features.Products.GetPopularCategories
{
    public class GetPopularCategoriesHandler(StoreDbContext storeDbContext) : IRequestHandler<GetPopularCategoriesQuery, List<PopularCategoryDto>>
    {
        public async Task<List<PopularCategoryDto>> Handle(GetPopularCategoriesQuery request, CancellationToken cancellationToken)
        {
            return await storeDbContext.PurchaseItems
                .Where(pi => pi.Purchase.ClientId == request.ClientId)
                .GroupBy(pi => pi.Product.Category)
                .Select(g => new PopularCategoryDto
                {
                    Category = g.Key,
                    TotalQuantity = g.Sum(pi => pi.Quantity)
                })
                .ToListAsync(cancellationToken);
        }
    }
}
