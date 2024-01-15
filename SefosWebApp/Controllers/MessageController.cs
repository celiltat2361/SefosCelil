using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SefosWebApp.Models;
using System.Net.Http;
using System.Threading.Tasks;
using Serilog; // Serilog için using ekleyin
using System;

namespace SefosWebApp.Controllers
{
    public class MessageController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;

        public MessageController(IConfiguration configuration, IHttpClientFactory httpClientFactory)
        {
            _configuration = configuration;
            _httpClient = httpClientFactory.CreateClient();
        }

        public IActionResult Index()
        {
            var model = new SefosRequestModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage(SefosRequestModel requestModel)
        {
            Log.Information("SendMessage called with model: {@Model}", requestModel); // Loglama eklendi

            if (!ModelState.IsValid)
            {

                Log.Warning("Model state is invalid: {@ModelState}", ModelState);
                return View("Index", requestModel);
            }


        if (requestModel.File != null && requestModel.File.Length > 0)
            {
                Log.Information("File upload started for file: {FileName}", requestModel.File.FileName);
            }

            try
            {
                var response = await _httpClient.PostAsJsonAsync(
                    $"{_configuration["SefosApiConfig:BaseUrl"]}/api/Message/Send",
                    requestModel);

                if (response.IsSuccessStatusCode)
                {
                    Log.Information("API call successful, redirecting to Feedback page");
                    return RedirectToAction("Feedback", new { success = true });
                }
                else
                {
                    Log.Warning("API call failed with status code: {StatusCode}", response.StatusCode);
                    return RedirectToAction("Feedback", new { success = false });
                }
            }
            catch (HttpRequestException ex)
            {
                Log.Error(ex, "Error occurred while making API call");
                return RedirectToAction("Feedback", new { success = false });
            }
        }

        public IActionResult Feedback(bool success)
        {
            var model = new FeedbackViewModel
            {
                IsSuccess = success,
                Message = success ? "Mesaj başarıyla gönderildi." : "Mesaj gönderilirken bir hata oluştu."
            };

            return View(model);
        }
    }
}
