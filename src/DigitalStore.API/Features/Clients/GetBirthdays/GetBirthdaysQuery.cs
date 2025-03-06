using MediatR;

namespace DigitalStore.API.Features.Clients.GetBirthdays
{
    public record GetBirthdaysQuery(DateTime Date) : IRequest<List<ClientBirthdayDto>>;
}
