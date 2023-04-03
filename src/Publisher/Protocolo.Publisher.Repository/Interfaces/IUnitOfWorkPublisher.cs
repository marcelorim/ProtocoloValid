using System;

namespace Protocolo.Publisher.Repository.Interfaces
{
    public interface IUnitOfWorkPublisher : IDisposable
    {
        void BeginTransaction();
        void Commit();
        void Rollback();
    }
}
