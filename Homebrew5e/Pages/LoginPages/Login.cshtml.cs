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
		public string? Username { get; set; }

		[BindProperty]
		public string? Password { get; set; }

		public LoginModel(DnDUserCollection userCollection)
		{
			this.userCollection = userCollection;
		}

		public void OnGet()
        {

        }

		public IActionResult OnPost()
		{
			// Authenticate user
			int userId = userCollection.LoginUser(Username, Password);

			if (userId != -1)
			{
				// User authenticated, store user ID in session

				// Set the user ID cookie
				Response.Cookies.Append("Homebrew5e.UserId", userId.ToString(), new CookieOptions
				{
					// Set cookie expiration if needed
					Expires = DateTimeOffset.Now.AddMinutes(20),

					// Other cookie options as needed
					HttpOnly = true // Anti-JS
				});

				// Redirect to the user's page or wherever you need to go after successful login
				return RedirectToPage("/User/UserProfile");
			}

			// Authentication failed, handle accordingly
			return Page();
		}

	}
}
