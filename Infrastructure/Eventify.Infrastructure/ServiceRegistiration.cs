using Eventify.Application.Abstractions.Services;
using Eventify.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Eventify.Infrastructure
{
    public static class ServiceRegistiration
    {
        public static void AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<IFileService, FileService>();
            services.AddScoped<ITextService, TextService>();
        }
    }
}
