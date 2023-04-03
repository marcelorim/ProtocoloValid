using Microsoft.AspNetCore.Http;
using Protocolo.Publisher.Business.Interfaces;
using Protocolo.Publisher.Business.Services;
using Protocolo.Publisher.Repository.Interfaces;
//using Protocolo.Publisher.Repository.Interfaces;
using Protocolo.Publisher.Repository;
using Protocolo.Publisher.Repository.Repositories;

namespace Protocolo.Publisher.App.Configuration
{
    public static class DependencyInjectionPublisherConfig
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
        {
            #region Services
            services.AddScoped<IProtocoloServices, ProtocoloServices>();
            #endregion

            #region Repository
            services.AddScoped<IUnitOfWorkPublisher, UnitOfWorkPublisher>();
            services.AddScoped<IProtocoloRepository, ProtocoloRepository>();
            services.AddScoped<DbSessionPublisher>();
            #endregion


            return services;
        }
    }
}
