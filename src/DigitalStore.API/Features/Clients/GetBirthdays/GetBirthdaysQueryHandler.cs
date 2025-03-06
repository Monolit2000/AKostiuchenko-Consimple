using DigitalStore.API.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DigitalStore.API.Features.Clients.GetBirthdays
{
    public class GetBirthdaysHandler : IRequestHandler<GetBirthdaysQuery, List<ClientBirthdayDto>>
    {
        private readonly StoreDbContext _context;

        public GetBirthdaysHandler(StoreDbContext context)
        {
            _context = context;
        }

        public async Task<List<ClientBirthdayDto>> Handle(GetBirthdaysQuery request, CancellationToken cancellationToken)
        {
            return await _context.Clients
                .Where(c => c.BirthDate.Day == request.Date.Day && c.BirthDate.Month == request.Date.Month)
                .Select(c => new ClientBirthdayDto
                {
                    Id = c.Id,
                    FullName = c.FullName
                })
                .ToListAsync(cancellationToken);
        }
    }
}
