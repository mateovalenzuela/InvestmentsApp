using ClientSwagger;
using System.Net;
using System.Text.Json;

namespace InvestmentsApp.Frontend.Services
{
    public class InvestmentService : IInvestmentService
    {
        private readonly ClientSwagger.ClientSwagger _apiClient;

        public InvestmentService(ClientSwagger.ClientSwagger apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<InvestmentDto> AddInvestment(InsertInvestmentDto dto)
        {
            try
            {
                // Realiza la llamada al cliente Swagger
                var response = await _apiClient.InvestmentPOSTAsync(dto);

                // Si la respuesta no es nula, la devuelve
                if (response != null)
                {
                    return response;
                }

                // Si la respuesta es nula, manejar el caso (opcional)
                throw new Exception("La API devolvió una respuesta nula.");
            }
            catch (ApiException ex)
            {
                // Manejar específicamente el código 201
                if (ex.StatusCode == (int)HttpStatusCode.Created)
                {
                    // Extraer la respuesta si es posible
                    var createdInvestment = JsonSerializer.Deserialize<InvestmentDto>(ex.Response);
                    return createdInvestment ?? throw new Exception("No se pudo deserializar la inversión creada.");
                }

                // Re-lanzar otras excepciones
                throw;
            }
        }
        

        public async Task DeleteInvestment(long id)
        {
            await _apiClient.InvestmentDELETEAsync(id);
        }

        public async Task<IEnumerable<InvestmentDto>> GetInvestments()
            => await _apiClient.InvestmentAllAsync();

        public async Task<IEnumerable<InvestmentDto>> GetInvestmentsByIdTypeInvestment(long id)
        {
            try
            {
                var invetments = await _apiClient.ByIdTypeInvestmentAsync(id);
                return invetments;
            }
            catch (ApiException ex) 
            {
                return new List<InvestmentDto>();
            }
        
        }


        public async Task<IEnumerable<InvestmentDto>> GetInvestmentsByTicker(string ticker)
        {
            try
            {
                var investments = await _apiClient.ByTickerAsync(ticker);
                return investments;
            }
            catch (ApiException ex)
            {
                return new List<InvestmentDto>();
            }
        }
           

        public async Task<InvestmentDto> GetSelectedInvestment(long id)
            => await _apiClient.InvestmentGETAsync(id);
       
        public async Task UpdateInvestment(long id, UpdateInvestmentDto dto)
        {
            await _apiClient.InvestmentPUTAsync(id, dto);
        }
    }
}
