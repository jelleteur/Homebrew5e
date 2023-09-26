using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Homebrew5e.Pages
{
    public class WorldModel : PageModel
    {
        private readonly ILogger<WorldModel> _logger;

        public WorldModel(ILogger<WorldModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}