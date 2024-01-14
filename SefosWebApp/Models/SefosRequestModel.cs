namespace SefosWebApp.Models
{
    public class SefosRequestModel
    {
        public Message MessageData { get; set; }
        public IFormFile File { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
    }
}
