using System;

namespace Protocolo.Consumer.Repository.Interfaces
{
    public interface IUnitOfWork
    {
        IProtocoloRepository Protocolo { get; }
    }
}
