using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace Sulmar.AspNetCore.Routing.RouteConstraints
{
    public static class ConstraintsExtensions
    {
        public static IServiceCollection AddPeselConstraint(this IServiceCollection services)
        {
            return services.Configure<RouteOptions>(options => options.ConstraintMap.Add("pesel", typeof(PeselValidatorRouteConstraint)));
        }

        public static IServiceCollection AddRegonConstraint(this IServiceCollection services)
        {
            return services.Configure<RouteOptions>(options => options.ConstraintMap.Add("regon", typeof(RegonValidatorRouteConstraint)));
        }

        public static IServiceCollection AddNipConstraint(this IServiceCollection services)
        {
            return services.Configure<RouteOptions>(options => options.ConstraintMap.Add("nip", typeof(NipValidatorRouteConstraint)));
        }

        public static IServiceCollection AddPolishConstraints(this IServiceCollection services)
        {
            return services
                .AddPeselConstraint()
                .AddRegonConstraint()
                .AddNipConstraint();
        }
    }

    
}
