using InvestmentsApp.Backend.Models;

namespace InvestmentsApp.Backend.Repositories
{
    public interface IInvestmentRepository : IRepository<Investmetn>
    {
        Task<IEnumerable<Investmetn>> GetActiveByTicker(string ticker);

        Task<IEnumerable<Investmetn>> GetActiveByTypeInvestment(long idTypeInvestment);

        IEnumerable<Investmetn> Search(Func<Investmetn, bool> filter, int limit);

    }
}
