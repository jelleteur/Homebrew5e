using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Homebrew5e.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public IActionResult OnGet()
        {
            string? userCookie = HttpContext.Request.Cookies["Homebrew5e.UserId"];

            if (userCookie != null)
            {
                return RedirectToPage("/UserPages/PrivateItemPage");
            }
            else  //geen login cookie

            {
                return Page();
            }
        }
    }
}