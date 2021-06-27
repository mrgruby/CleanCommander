using CleanCommander.Application.Contracts.Persistence;
using CleanCommander.Persistence;
using CleanCommander.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GloboTicket.TicketManagement.Persistence
{
    /// <summary>
    /// This class extends the service collection, which is normally found in the Startup.cs class. This class is not available here, since we
    /// are doing clean architecture. This is for service registration. Here, we add support for dependency injection. We add the DbContext, 
    /// and specify that we will use SqlServer. Finally, the connectionstring is registered.
    /// 
    /// These registrations are made here since PersistenceServiceRegistration is part of infrastructure. The interfaces that are implemented via DI, exist in the 
    /// Core/Application, and if this file were there, then Core/Application would have to reference infrastructure, which would violate clean architecture.
    /// </summary>
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CleanCommanderDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("CleanCommanderConnectionString")));

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            services.AddScoped<IPlatformRepository, PlatformRepository>();
            services.AddScoped<ICommandRepository, CommandRepository>();

            return services;    
        }
    }
}
