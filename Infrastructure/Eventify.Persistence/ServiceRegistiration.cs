using Eventify.Application.Abstractions.Services;
using Eventify.Persistence.DbContexts;
using Eventify.Persistence.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Eventify.Persistence
{
    public static class ServiceRegistiration
    {
        public static void AddPersistanceServices(this IServiceCollection services)
        {
            services.AddScoped<IEventService, EventService>();
            services.AddDbContext<EventifyDbContext>();
        }
    }
}
