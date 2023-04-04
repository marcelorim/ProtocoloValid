using Protocolo.Consumer.Repository.Interfaces;
using Protocolo.Consumer.Repository.Repositories;

namespace Protocolo.Consumer.App.Configuration
{
    public static class DependencyInjectionConsumerConfig
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
        {
            #region Repository
            services.AddSingleton<IUnitOfWork, UnitOfWork>();
            services.AddSingleton<IProtocoloRepository, ProtocoloRepository>();
            #endregion


            return services;
        }
    }
}
