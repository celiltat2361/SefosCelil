using System.ComponentModel.DataAnnotations;

namespace SefosApi.Models
{
    public class SefosRequestModel
    {
        public string? FunctionBoxUuid { get; set; }

        [Required(ErrorMessage = "The Subject field is required.")]
        public string Subject { get; set; }

        public string Body { get; set; }
        public List<Attachment>? Attachments { get; set; }
        public string? ExternalText { get; set; }
        public List<SefosParticipant>? SefosParticipants { get; set; }
        public List<ExternalParticipant> ExternalParticipants { get; set; }
        public ApiSettings? Settings { get; set; }
    }
}
