using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Wfm.Core.Abstractions;
using Wfm.Service;

namespace Wfm.DI
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddWfmService(this IServiceCollection service)
        {
            service.TryAddScoped<IManagerService, ManagerService>();
            return service;
        }
    }
}