using Protocolo.Models.DTO;
using Protocolo.Models.Entities;

namespace Protocolo.Consumer.Repository.Interfaces
{
    public interface IProtocoloRepository : IBaseRepository<ProtocoloEntity>
    {
        Task<ProtocoloEntity> GetByParametro(long? numProtocolo, long? numCpf, long? numRg);
    }
}
