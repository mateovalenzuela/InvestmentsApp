using InvestmentsApp.Backend.DTOs.Investment;
using InvestmentsApp.Backend.DTOs.TypeInvestment;
using InvestmentsApp.Backend.Models;

namespace InvestmentsApp.Backend.Services
{
    public interface IInvestmentService : IService<InvestmentDto, InsertInvestmentDto, UpdateInvestmentDto>
    {
        Task<IEnumerable<InvestmentDto>> GetByTicker(string ticker);

        Task<IEnumerable<InvestmentDto>> GetByTypeInvestment(long idTypeInvestment);

        Task<bool> Validate(InsertInvestmentDto dto);
        Task<bool> Validate(long id, UpdateInvestmentDto dto);

    }
}
