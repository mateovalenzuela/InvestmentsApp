using ClientSwagger;

namespace InvestmentsApp.Frontend.Services
{
    public class TypeInvestmentService : ITypeInvestmentService
    {
        private readonly ClientSwagger.ClientSwagger _apiClient;

        public TypeInvestmentService(ClientSwagger.ClientSwagger apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task AddTypeInvestment(InsertTypeInvestmentDto dto)
        {
            await _apiClient.TypeInvestmentPOSTAsync(dto);
        }

        public async Task DeleteTypeInvestment(long id)
        {
            await _apiClient.TypeInvestmentDELETEAsync(id);
        }

        public async Task<TypeInvestmentDto> GetSelectedTypeInvestment(long id)
            => await _apiClient.TypeInvestmentGETAsync(id);

        public async Task<IEnumerable<TypeInvestmentDto>> GetTypesInvestment()
            => await _apiClient.TypeInvestmentAllAsync();

        public async Task UpdateTypeInvestment(long id, UpdateTypeInvestmentDto dto)
        {
            await _apiClient.TypeInvestmentPUTAsync(id, dto);
        }
    }
}
