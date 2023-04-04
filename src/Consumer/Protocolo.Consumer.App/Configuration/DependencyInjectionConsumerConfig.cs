using Protocolo.Consumer.Repository;
using Protocolo.Consumer.Repository.Interfaces;
using Protocolo.Consumer.Repository.Repositories;
using Protocolo.Consumer.Service.Interfaces;
using Protocolo.Consumer.Service.Services;

namespace Protocolo.Consumer.App.Configuration
{
    public static class DependencyInjectionConsumerConfig
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
        {
            #region Services
            services.AddSingleton<IProtocoloServices, ProtocoloServices>();
            #endregion

            #region Repository
            services.AddSingleton<IUnitOfWork, UnitOfWork>();
            services.AddSingleton<IProtocoloRepository, ProtocoloRepository>();
            #endregion


            return services;
        }
    }
}
