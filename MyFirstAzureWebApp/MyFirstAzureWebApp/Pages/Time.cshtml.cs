using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyFirstAzureWebApp.Pages
{
    public class TimeModel : PageModel
    {
        private readonly ILogger<TimeModel> _logger;

        public DateTime ServerTimeUtc { get; set; }

        public TimeModel(ILogger<TimeModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            ServerTimeUtc = DateTime.UtcNow;
        }
    }

}
