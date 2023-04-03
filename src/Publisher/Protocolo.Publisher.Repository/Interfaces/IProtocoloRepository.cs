using Protocolo.Models.Entities;

namespace Protocolo.Publisher.Repository.Interfaces
{
    public interface IProtocoloRepository
    {
        Task<ProtocoloEntity> GetByProtocolo(int numProtocolo);
        Task<ProtocoloEntity> GetByCpf(int numCpf);
        Task<ProtocoloEntity> GetByRg(int numRg);
    }
}
