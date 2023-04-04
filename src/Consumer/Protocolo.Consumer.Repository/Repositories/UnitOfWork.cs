using Protocolo.Consumer.Repository.Interfaces;

namespace Protocolo.Consumer.Repository.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(IProtocoloRepository protocoloRepository)
        {
            Protocolo = protocoloRepository;
        }

        public IProtocoloRepository Protocolo { get; }

    }
}
