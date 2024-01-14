using System.ComponentModel.DataAnnotations;

namespace SefosApi.Models
{
    public class ExternalParticipant
    {
        public string? AuthenticationIdentifier { get; set; }
        public string? AuthenticationMethod { get; set; }
        public bool Configured { get; set; }
        [Required(ErrorMessage = "Email field is required")]
        public string Email { get; set; }
        public string Language { get; set; }
    }
}
