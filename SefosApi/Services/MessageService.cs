using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using SefosApi.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SefosApi.Services
{
    public class MessageService : IMessageService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public MessageService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _configuration["SefosApiConfig:BearerToken"]);
        }

        public async Task<HttpResponseMessage> SendMessageAsync(SefosRequestModel model)
        {
            var messageRequest = new
            {
                functionbox_uuid = _configuration["SefosApiConfig:FunctionBoxUuid"],
                subject = model.Subject,
                body = model.Body,
                attachments = new List<object>(),
                external_text = "",
                sefos_participants = new[] { new { email = _configuration["SefosApiConfig:ReceiverEmail"] } },
                external_participants = model.ExternalParticipants,
                settings = model.Settings
            };

            var content = new StringContent(JsonConvert.SerializeObject(messageRequest), Encoding.UTF8, "application/json");
            return await _httpClient.PostAsync(_configuration["SefosApiConfig:BaseUrl"], content);
        }
    }

}
