namespace InvestmentsApp.Backend.Repositories
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> GetAllActives();

        Task<T> GetActive(long id);

        Task Add(T entity);

        void Update(T entity);

        void BajaLogica(T entity);

        Task Save();
    }
}
