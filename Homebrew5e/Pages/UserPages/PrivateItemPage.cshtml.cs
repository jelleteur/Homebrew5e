using Homebrew5e.Core.Collections;
using Homebrew5e.Core.Models;
using Homebrew5e.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Homebrew5e.App.Pages.UserPages
{
    public class PrivateItemPageModel : PageModel
    {
        private Item item;
        public List<Item> UserItems = new List<Item>();

        [BindProperty]
        public int userID {  get; set; }
		[BindProperty]
		public int SelectedItemId { get; set; }
        public PrivateItemPageModel(Item item)
        {
            this.item = item;
        }

        

        public IActionResult OnGet()
        {
            string userIdCookieValue = HttpContext.Request.Cookies["Homebrew5e.UserId"];

            if (userIdCookieValue != null)
            {
                userID = int.Parse(userIdCookieValue);
                UserItems = item.GetByUserID(new ItemRepository(), userID);

				return Page();
            }
            else
            {
                return Redirect($"/Index");
            }
        }

		public IActionResult OnPostItemInfoPage()
		{
			return Redirect($"/UserPages/ItemInfoUpdate?id={SelectedItemId}");
		}

        public IActionResult OnPostItemDelete()
        {
			return Redirect($"/ItemPages/ItemDelete?id={SelectedItemId}");
		}
	}
}
