using Homebrew5e.Core.Collections;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Homebrew5e.App.Pages.LoginPages
{
    public class RegisterModel : PageModel
    {
        private DnDUserCollection userCollection;

        [BindProperty]
        public string UserName { get; set; }
        [BindProperty]
        public string Email { get; set; }
        [BindProperty]
        public string Password { get; set; }


        public RegisterModel(DnDUserCollection userCollection)
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
            if (UserName != null && Password != null && Email != null)
            {
                if (userCollection.UserMailDuplicateCheck(Email, UserName))
                {
                    int userId = userCollection.RegisterUser(UserName, Password, Email);

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
                }
                else
                {
                    TempData["PopupMessage"] = "Username or Email is already in use.";

                    return RedirectToPage();
                }


            }

            return Page();

        }
    }
}
