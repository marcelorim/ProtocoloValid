using Protocolo.Models.DTO;
using Protocolo.Models.Entities;

namespace Protocolo.Consumer.Service.Interfaces
{
    public interface IProtocoloServices
    {
        Task<RetornoDTO> InserirDadosProtocolo(ProtocoloEntity entity);
    }
}
