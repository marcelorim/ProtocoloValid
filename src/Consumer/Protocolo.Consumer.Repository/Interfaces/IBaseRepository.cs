namespace Protocolo.Consumer.Repository.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        Task<bool> Insert(T entity);
    }
}
