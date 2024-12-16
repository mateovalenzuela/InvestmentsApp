using ClientSwagger;
using System.Net;
using System.Text.Json;

namespace InvestmentsApp.Frontend.Services
{
    public class TypeInvestmentService : ITypeInvestmentService
    {
        private readonly ClientSwagger.ClientSwagger _apiClient;

        public TypeInvestmentService(ClientSwagger.ClientSwagger apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<TypeInvestmentDto> AddTypeInvestment(InsertTypeInvestmentDto dto)
        {
            try
            {
                // Realiza la llamada al cliente Swagger
                var response = await _apiClient.TypeInvestmentPOSTAsync(dto);

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
                    var createdInvestment = JsonSerializer.Deserialize<TypeInvestmentDto>(ex.Response);
                    return createdInvestment ?? throw new Exception("No se pudo deserializar la inversión creada.");
                }

                // Re-lanzar otras excepciones
                throw;
            }
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
