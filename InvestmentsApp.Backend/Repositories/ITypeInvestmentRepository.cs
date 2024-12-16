using InvestmentsApp.Backend.Models;

namespace InvestmentsApp.Backend.Repositories
{
    public interface ITypeInvestmentRepository : IRepository<TypeInvestment>
    {
        IEnumerable<TypeInvestment> Search(Func<TypeInvestment, bool> filter, int limit);
    }
}
