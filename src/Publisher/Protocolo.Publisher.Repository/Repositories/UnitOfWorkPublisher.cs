using Protocolo.Publisher.Repository.Interfaces;

namespace Protocolo.Publisher.Repository.Repositories
{
    #region Abertura de conexão por transação
    public sealed class UnitOfWorkPublisher : IUnitOfWorkPublisher
    {
        private readonly DbSessionPublisher _session;

        public UnitOfWorkPublisher(DbSessionPublisher session)
        {
            _session = session;
        }

        public void BeginTransaction()
        {
            _session.Transaction = _session.Connection.BeginTransaction();
        }

        public void Commit()
        {
            _session.Transaction.Commit();
            Dispose();
        }

        public void Rollback()
        {
            _session.Transaction.Rollback();
            Dispose();
        }

        public void Dispose() => _session.Transaction?.Dispose();
    }
    #endregion

    #region Abertura de conexão dentro da classe repository
    //public class UnitOfWork : IUnitOfWork
    //{
    //    public UnitOfWork(IDocumentoRepository documentoRepository, IAssinaturaDigitalRepository assinaturaDigitalRepository)
    //    {
    //        Documentos = documentoRepository ?? throw new ArgumentNullException(nameof(documentoRepository));
    //        Assinaturas = assinaturaDigitalRepository ?? throw new ArgumentNullException(nameof(assinaturaDigitalRepository));
    //    }

    //    public IDocumentoRepository Documentos { get; }
    //    public IAssinaturaDigitalRepository Assinaturas { get; }
    //}
    #endregion
}
