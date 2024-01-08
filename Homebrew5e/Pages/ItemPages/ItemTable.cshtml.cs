using Homebrew5e.Core.Collections;
using Homebrew5e.Core.Interfaces;
using Homebrew5e.Core.Models;
using Homebrew5e.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Homebrew5e.App.Pages
{
    public class ItemTableModel : PageModel
    {
        private readonly ItemCollection itemCollection;

        [BindProperty]
        public int SelectedItemId { get; set; }

        public ItemTableModel(ItemCollection itemCollection)
        {
            this.itemCollection = itemCollection;
            //ItemCollection _itemCollection = new ItemCollection(new ItemRepository());
        }

        public List<Item>? Items { get; private set; }

        public IActionResult OnGet()
        {
            string userIdCookieValue = HttpContext.Request.Cookies["Homebrew5e.UserId"];

            if (userIdCookieValue != null)
            {
                Response.Cookies.Append("Homebrew5e.UserId", userIdCookieValue, new CookieOptions
                {
                    Expires = DateTimeOffset.Now.AddMinutes(20)
                });
                Items = itemCollection.GetAllItems();
                return Page();
            }
            else
            {
                return Redirect($"/Index");
            }

        }

        public IActionResult OnPostItemInfoPage()
        {
            return Redirect($"/ItemPages/ItemInfo?id={SelectedItemId}");
        }
    }
}
