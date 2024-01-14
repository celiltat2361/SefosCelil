namespace SefosApi.Models
{
    public class Attachment
    {
        public string Content { get; set; } // base64 content of attachment
        public string Name { get; set; } // Name of attachment
        public string Type { get; set; } // mime type of attachment
    }
}
