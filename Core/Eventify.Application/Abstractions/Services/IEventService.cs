using Eventify.Application.DTOs;
using Eventify.Application.RequestParameters;
using Eventify.Domain.Entities;
using Eventify.Domain.ValueObjects;

namespace Eventify.Application.Abstractions.Services
{
    public interface IEventService
    {
        Task CreateEventAsync(CreateEventDTO createEventDTO);
        Task<IEnumerable<EventDTO>> GetAllEventsAsync(Pagination pagination);
    }
}
