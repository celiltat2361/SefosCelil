using Microsoft.Extensions.Configuration;
using Moq;
using Moq.Protected;
using SefosApi.Models;
using SefosApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SefosApi.Tests.Services
{
    public class MessageServiceTests
    {
        [Fact]
        public async Task SendMessageAsync_WithValidRequest_ReturnsSuccessResponse()
        {
            var mockHttpMessageHandler = new Mock<HttpMessageHandler>();
            var responseMessage = new HttpResponseMessage(HttpStatusCode.OK);
            mockHttpMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(responseMessage);

            var httpClient = new HttpClient(mockHttpMessageHandler.Object);

            var configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(new Dictionary<string, string>
                {
            {"SefosApiConfig:BaseUrl", "http://testapi.com"},
            {"SefosApiConfig:FunctionBoxUuid", "test-uuid"}
                })
                .Build();

            var service = new MessageService(httpClient, configuration);

            var requestModel = new SefosRequestModel
            {
                Subject = "Test",
                Body = "Test Body",
                ExternalParticipants = new List<ExternalParticipant> { new ExternalParticipant { Email = "test@example.com" } }
            };

            var result = await service.SendMessageAsync(requestModel);

            Assert.True(result.IsSuccessStatusCode);
        }

    }
}
