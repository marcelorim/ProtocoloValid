using Protocolo.Models.Entities;

namespace Protocolo.Publisher.Repository.Interfaces
{
    public interface IProtocoloRepository
    {
        Task<ProtocoloEntity> GetByParametro(long? numProtocolo, long? numCpf, long? numRg);
    }
}
