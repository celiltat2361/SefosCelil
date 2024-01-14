using System.ComponentModel.DataAnnotations;

namespace SefosApi.Models
{
    public class SefosRequestModel
    {
        public string? FunctionBoxUuid { get; set; }

        [Required(ErrorMessage = "The Subject field is required.")]
        public string Subject { get; set; }

        public string Body { get; set; }
        public List<Attachment>? Attachments { get; set; } = new List<Attachment>();
        public string? ExternalText { get; set; } = string.Empty;
        public List<SefosParticipant>? SefosParticipants { get; set; } = new List<SefosParticipant>();
        public List<ExternalParticipant> ExternalParticipants { get; set; } = new List<ExternalParticipant>();
        public ApiSettings? Settings { get; set; } = new ApiSettings();
    }
}
