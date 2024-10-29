using AppLightBreaksSolution.DTOS;
using System.Text.Json;

namespace AppLightBreaksSolution.Services
{
    public class ScheduleService : ISchedulerService
    {
        private HttpClient _httpClient;

        public ScheduleService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<dynamic> Get(string DocumentNumber,string DocumentType)
        {
            var baseUrl = $"{_httpClient.BaseAddress}/{DocumentNumber}/{DocumentType}";
            var response = await _httpClient.GetAsync(baseUrl);
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Error en la solicitud: {response.StatusCode}");
            }
            var body = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            try
            {
                var schedule = JsonSerializer.Deserialize<dynamic>(body, options);
                return schedule ?? throw new JsonException("El contenido deserializado es nulo.");
            }
            catch (JsonException ex)
            {
                // Manejar el error de deserialización aquí
                throw new InvalidOperationException("Error al deserializar la respuesta JSON.", ex);
            }
        }

    }
}
