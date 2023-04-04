using Protocolo.Models.DTO;
using Protocolo.Models.Entities;

namespace Protocolo.Consumer.Service.Interfaces
{
    public interface IProtocoloServices
    {
        Task<bool> InserirDadosProtocolo(ProtocoloEntity entity);
    }
}
