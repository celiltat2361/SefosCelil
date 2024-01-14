namespace SefosWebApp.Models
{
    public class Message
    {
        public Message(string senderEmail, string subject, string body)
        {
            this.ExternalParticipants.Add(new ExternalParticipant
            {
                email = senderEmail,
                language = "SE",
                configured = true
            });
            this.Subject = subject;
            this.Body = body;
        }

        public List<ExternalParticipant> ExternalParticipants { get; set; } = new List<ExternalParticipant>();
        public string Subject { get; set; }
        public string Body { get; set; }
    }

}
