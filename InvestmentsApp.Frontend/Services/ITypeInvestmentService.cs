namespace InvestmentsApp.Frontend.Services
{
    public interface ITypeInvestmentService
    {
        Task AddTypeInvestment(ClientSwagger.InsertTypeInvestmentDto dto);

        Task<ClientSwagger.TypeInvestmentDto> GetSelectedTypeInvestment(long id);

        Task UpdateTypeInvestment(long id, ClientSwagger.UpdateTypeInvestmentDto dto);

        Task DeleteTypeInvestment(long id);

        Task<IEnumerable<ClientSwagger.TypeInvestmentDto>> GetTypesInvestment();
    }
}
