using Microsoft.AspNetCore.Mvc;
using backend.Services;
using backend.Models;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UrlController : ControllerBase
    {
        private readonly UrlService _urlService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UrlController(UrlService urlService, IHttpContextAccessor httpContextAccessor)
        {
            _urlService = urlService;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpPost("shorten")]
        public IActionResult ShortenUrl([FromBody] UrlModel model)
        {
            if (string.IsNullOrEmpty(model.OriginalUrl))
                return BadRequest("URL cannot be empty.");

            var request = _httpContextAccessor.HttpContext!.Request;
            var baseUrl = $"{request.Scheme}://{request.Host}";

            var result = _urlService.CreateShortUrl(model.OriginalUrl, baseUrl);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult RedirectToOriginal(string id)
        {
            var url = _urlService.GetOriginalUrl(id);
            if (url == null)
                return NotFound("Short URL not found.");

            return Redirect(url.OriginalUrl);
        }
    }
}
