using Protocolo.Models.Entities;

namespace Protocolo.Publisher.Business.Interfaces
{
    public interface IProtocoloServices
    {
        Task MontaDadosEnviaFila();
        Task<ProtocoloEntity> ObterPorProtocolo(int numProtocolo);
    }
}
