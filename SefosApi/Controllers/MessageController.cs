using Microsoft.AspNetCore.Mvc;
using SefosApi.Models;
using SefosApi.Services;
using System.Threading.Tasks;

namespace SefosApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _messageService;

        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpPost("Send")]
        public async Task<IActionResult> Send([FromBody] SefosRequestModel messageRequest)
        {
            
            if (messageRequest == null)
            {
                return BadRequest("Message request cannot be null.");
            }


            var response = await _messageService.SendMessageAsync(messageRequest);

            if (response.IsSuccessStatusCode)
            {
                
                var responseContent = await response.Content.ReadAsStringAsync();
                return Ok(new { success = true, message = "Message sent successfully", responseBody = responseContent });
            }
            else
            {
                
                var errorContent = await response.Content.ReadAsStringAsync();
                return StatusCode((int)response.StatusCode, new { success = false, message = "Error: " + errorContent });
            }
        }
    }
}
