using Microsoft.Extensions.DependencyInjection;

namespace rjff.avmb.application
{
    public static class ApplicationModule
    {
        public static IServiceCollection AddApplicationModule(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            return services.AddMediatR(cfg
                => cfg.RegisterServicesFromAssembly(typeof(application.ApplicationModule).Assembly));
        }
    }
}
