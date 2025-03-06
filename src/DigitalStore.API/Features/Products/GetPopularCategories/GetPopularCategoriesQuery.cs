using MediatR;

namespace DigitalStore.API.Features.Products.GetPopularCategories
{
    public record GetPopularCategoriesQuery(int ClientId) : IRequest<List<PopularCategoryDto>>;
}
