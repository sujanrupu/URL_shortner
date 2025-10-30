namespace backend.Models
{
    public class UrlModel
    {
        public string Id { get; set; } = Guid.NewGuid().ToString().Substring(0, 8);
        public string OriginalUrl { get; set; } = "";
        public string ShortUrl { get; set; } = "";
    }
}
