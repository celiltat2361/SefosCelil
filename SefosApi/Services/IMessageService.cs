using SefosApi.Models;

namespace SefosApi.Services
{
    public interface IMessageService
    {
        Task<HttpResponseMessage> SendMessageAsync(SefosRequestModel model);
    }
}
