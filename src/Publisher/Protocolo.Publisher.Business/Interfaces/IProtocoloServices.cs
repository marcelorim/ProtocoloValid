using Protocolo.Models.Entities;

namespace Protocolo.Publisher.Business.Interfaces
{
    public interface IProtocoloServices
    {
        Task MontaDadosEnviaFila();
        Task<ProtocoloEntity> ObterPorParametro(long? numProtocolo, long? numCpf, long? numRg);
    }
}
