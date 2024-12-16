using InvestmentsApp.Backend.Models;

namespace InvestmentsApp.Backend.Repositories
{
    public interface IInvestmentRepository : IRepository<Investment>
    {
        Task<IEnumerable<Investment>> GetActiveByTicker(string ticker);

        Task<IEnumerable<Investment>> GetActiveByTypeInvestment(long idTypeInvestment);

        IEnumerable<Investment> Search(Func<Investment, bool> filter, int limit);

    }
}
