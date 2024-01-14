namespace SefosWebApp.Models
{
    public class ExternalParticipant
    {
        public string email { get; set; }
        public string language { get; set; }
        public string? authentication_method { get; set; }
        public string? authentication_identifier { get; set; }
        public bool configured { get; set; }
    }
}
