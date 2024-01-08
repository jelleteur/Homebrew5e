using Homebrew5e.Core.Models;
using Homebrew5e.DAL;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;

namespace Homebrew5e.App.Pages.UserPages
{
    public class ItemInfoUpdateModel : PageModel
    {
        [BindProperty]
        public Item ItemDetails { get; private set; }

        [BindProperty]
        public int ItemID { get; set; }

        [BindProperty]
        public string ItemName { get; set; }

        [BindProperty]
        public string ItemAttribute { get; set; }

        [BindProperty]
        public string ItemAttributeEnum { get; set; }

        [BindProperty]
        public string ItemDescription { get; set; }


        public ItemInfoUpdateModel()
        {
            ItemDetails = new Item();
        }

        public IActionResult OnGet(int id)
        {
            string userIdCookieValue = HttpContext.Request.Cookies["Homebrew5e.UserId"];

            if (userIdCookieValue == null)
            {
                return Redirect("/Index");
            }

            Response.Cookies.Append("Homebrew5e.UserId", userIdCookieValue, new CookieOptions
            {
                Expires = DateTimeOffset.Now.AddMinutes(20)
            });

            ItemRepository repository = new ItemRepository();
            ItemDetails = ItemDetails.GetByID(repository, id);

            if (ItemDetails == null)
            {
                return Redirect("/Error");
            }

            // Set values for input fields
            ItemID = ItemDetails.GetID();
            ItemName = ItemDetails.GetName();
            ItemAttribute = ItemDetails.GetAttributeForUpdate();
            ItemAttributeEnum = // Logic to retrieve itemAttributeEnum based on ItemDetails
            ItemDescription = ItemDetails.GetDescription();

            return Page();
        }

        public IActionResult OnPostUpdateItem()
        {
            ItemRepository repository = new ItemRepository();
            string attribute = ItemAttribute + " " + ItemAttributeEnum.ToString();
            ItemDetails.Update(repository, ItemName, attribute, ItemDescription, ItemID);

            return Redirect($"/UserPages/PrivateItemPage");
        }
    }
}