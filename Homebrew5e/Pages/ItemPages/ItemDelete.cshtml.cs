using Homebrew5e.App.Pages.UserPages;
using Homebrew5e.Core.Models;
using Homebrew5e.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Homebrew5e.App.Pages.ItemPages
{
	public class ItemDeleteModel : PageModel
	{
		public Item ItemDetails { get; private set; }
				
		[BindProperty]
		public int SelectedItemId { get; set; }
		public ItemDeleteModel(Item item)
		{
			ItemDetails = item;
		}

		public IActionResult OnGet()
		{
			string userIdCookieValue = HttpContext.Request.Cookies["Homebrew5e.UserId"];
			int UserID = Convert.ToInt32(userIdCookieValue);
			if (userIdCookieValue != null)
			{
				if (int.TryParse(Request.Query["id"], out int itemId))
				{
					ItemRepository repository = new ItemRepository();
					ItemDetails = ItemDetails.GetByID(repository, itemId);
					int ItemUserID = ItemDetails.GetUserID();
					if (ItemUserID == UserID)
					{
						return Page();
					}
					else
					{
						return Redirect($"/Error");
					}
				}
				else
				{
					return Redirect($"/Error");
				}
			}
			else
			{
				return Redirect($"/Index");
			}

		}

		public IActionResult OnPostDeleteItem()
		{
			Item item = new Item();
			ItemRepository repository = new ItemRepository();

			item.Delete(repository, SelectedItemId);

			return Redirect($"/UserPages/PrivateItemPage");
		}
	}
}