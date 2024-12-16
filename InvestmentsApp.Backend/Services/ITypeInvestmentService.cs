using InvestmentsApp.Backend.DTOs.TypeInvestment;

namespace InvestmentsApp.Backend.Services
{
    public interface ITypeInvestmentService : IService<TypeInvestmentDto, InsertTypeInvestmentDto, UpdateTypeInvestmentDto>
    {
        bool Validate(InsertTypeInvestmentDto dto);
        bool Validate(long id, UpdateTypeInvestmentDto dto);
    }
}
