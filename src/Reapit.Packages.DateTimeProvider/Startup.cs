using Microsoft.Extensions.DependencyInjection;
using Reapit.Packages.DateTimeProvider.Services;

namespace Reapit.Packages.DateTimeProvider;

/// <summary>
/// Service configuration methods for the Reapit.Packages.DateTimeProvider package
/// </summary>
public static class Startup
{
    /// <summary>
    /// Adds a services for the Reapit.Packages.DateTimeProvider package to the provided IServiceCollection.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> to add the services to</param>
    /// <returns>A reference to the IServiceCollection instance after the operation has completed.</returns>
    public static IServiceCollection AddDateTimeService(this IServiceCollection services)
        => services.AddTransient<IDateTimeService, DateTimeService>();
}