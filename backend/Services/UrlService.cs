using backend.Models;
using System.Collections.Concurrent;

namespace backend.Services
{
    public class UrlService
    {
        private readonly ConcurrentDictionary<string, UrlModel> _urls = new();

        public UrlModel CreateShortUrl(string originalUrl, string baseUrl)
        {
            var newUrl = new UrlModel
            {
                OriginalUrl = originalUrl,
                ShortUrl = $"{baseUrl}/{Guid.NewGuid().ToString().Substring(0, 6)}"
            };

            _urls[newUrl.ShortUrl.Split('/').Last()] = newUrl;
            return newUrl;
        }

        public UrlModel? GetOriginalUrl(string id)
        {
            _urls.TryGetValue(id, out var result);
            return result;
        }
    }
}
