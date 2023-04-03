using Protocolo.Models.DTO;
using Protocolo.Models.Entities;

namespace Protocolo.Consumer.Repository.Interfaces
{
    public interface IProtocoloRepository
    {
        Task<RetornoDTO> Insert(ProtocoloEntity entity);
        Task<ProtocoloEntity> GetByProtocolo(int numProtocolo);
        Task<ProtocoloEntity> GetByCpf(int numCpf);
        Task<ProtocoloEntity> GetByRg(int numRg);
    }
}
