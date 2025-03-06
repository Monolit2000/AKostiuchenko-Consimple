using DigitalStore.API.Features.Clients.GetBirthdays;
using DigitalStore.API.Features.Products.GetPopularCategories;
using DigitalStore.API.Features.Purchases;
using DigitalStore.API.Features.Purchases.GetRecentPurchases;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace DigitalStore.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StoreController(
        IMediator mediator) : ControllerBase
    {
       
        [HttpGet("client/getBirthdaysList/{date}")]
        [ProducesResponseType(typeof(List<ClientBirthdayDto>), StatusCodes.Status200OK)]
  
        public async Task<IActionResult> Get(DateTime date)
        {
            var query = new GetBirthdaysQuery(date);
            var result = await mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("purchase/recentPurchases/{days}")]
        [ProducesResponseType(typeof(List<RecentPurchaseDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetRecentPurchases(int days)
        {
            var query = new GetRecentPurchasesQuery(days);
            var result = await mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("products/getPopularCategoriesClient/{clientId}")]
        [ProducesResponseType(typeof(List<PopularCategoryDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(int clientId)
        {
            var query = new GetPopularCategoriesQuery(clientId);
            var result = await mediator.Send(query);
            return Ok(result);
        }
    }
}
