using Microsoft.AspNetCore.Mvc;
using Moq;
using SefosApi.Controllers;
using SefosApi.Models;
using SefosApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SefosApi.Tests.Controllers
{
    public class MessageControllerTests
    {
        [Fact]
        public async Task Send_ReturnsSuccess_WhenRequestIsValid()
        {
            var mockService = new Mock<IMessageService>();
            mockService.Setup(s => s.SendMessageAsync(It.IsAny<SefosRequestModel>()))
                       .ReturnsAsync(new HttpResponseMessage(HttpStatusCode.OK));

            var controller = new MessageController(mockService.Object);

            var result = await controller.Send(new SefosRequestModel
            {
                Subject = "Test",
                Body = "Test Body",
                ExternalParticipants = new List<ExternalParticipant> { new ExternalParticipant { Email = "test@example.com" } }
            });

            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(200, okResult.StatusCode);
        }

    }
}
