using MediatR;

namespace MicroservicioAPI.Services
{
    public static class RegistrationService
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(typeof(CreateProductHandler).Assembly);
            return services;
        }
    }
}
