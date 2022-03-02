using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationServices(this IServiceCollection service)
        {
            var assembly = Assembly.GetExecutingAssembly();
            service.AddMediatR(assembly);
            service.AddAutoMapper(assembly);
        }
    }
}
