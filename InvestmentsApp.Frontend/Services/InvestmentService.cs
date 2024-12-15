using ClientSwagger;

namespace InvestmentsApp.Frontend.Services
{
    public class InvestmentService : IInvestmentService
    {
        private readonly ClientSwagger.ClientSwagger _apiClient;

        public InvestmentService(ClientSwagger.ClientSwagger apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task AddInvestment(InsertInvestmentDto dto)
        {
            await _apiClient.InvestmentPOSTAsync(dto);
        }

        public async Task DeleteInvestment(long id)
        {
            await _apiClient.InvestmentDELETEAsync(id);
        }

        public async Task<IEnumerable<InvestmentDto>> GetInvestments()
            => await _apiClient.InvestmentAllAsync();

        public async Task<InvestmentDto> GetSelectedInvestment(long id)
            => await _apiClient.InvestmentGETAsync(id);
       

        public async Task UpdateInvestment(long id, UpdateInvestmentDto dto)
        {
            await _apiClient.InvestmentPUTAsync(id, dto);
        }
    }
}
