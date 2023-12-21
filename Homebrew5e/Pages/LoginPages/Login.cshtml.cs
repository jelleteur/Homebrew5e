using Homebrew5e.Core.Collections;
using Homebrew5e.Core.Interfaces;
using Homebrew5e.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Homebrew5e.App.Pages.LoginPages
{
    public class LoginModel : PageModel
    {
        private DnDUserCollection userCollection;

        [BindProperty]
        public string? Email { get; set; }

        [BindProperty]
        public string? Password { get; set; }

        public LoginModel(DnDUserCollection userCollection)
        {
            this.userCollection = userCollection;
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

        public IActionResult OnPost()
        {
            int userId = userCollection.LoginUser(Email, Password);

            if (userId != -1)
            {
                // cookiesetup
                Response.Cookies.Append("Homebrew5e.UserId", userId.ToString(), new CookieOptions
                {
                    Expires = DateTimeOffset.Now.AddMinutes(20),

                    HttpOnly = true // Anti-JS
                });

                return RedirectToPage("/UserPages/PrivateItemPage");
            }

            //foute login
            return Page();
        }

    }
}
