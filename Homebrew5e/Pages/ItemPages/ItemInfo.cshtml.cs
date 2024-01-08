using Homebrew5e.Core.Models;
using Homebrew5e.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Org.BouncyCastle.Asn1.Ocsp;

public class ItemInfoModel : PageModel
{
    public Item ItemDetails { get; private set; }

    public ItemInfoModel()
    {
        ItemDetails = new Item();
    }

    public IActionResult OnGet()
    {
        string userIdCookieValue = HttpContext.Request.Cookies["Homebrew5e.UserId"];

        if (userIdCookieValue != null)
        {
            Response.Cookies.Append("Homebrew5e.UserId", userIdCookieValue, new CookieOptions
            {
                Expires = DateTimeOffset.Now.AddMinutes(20)
            });
            if (int.TryParse(Request.Query["id"], out int itemId))
            {
                ItemRepository repository = new ItemRepository();
                ItemDetails = ItemDetails.GetByID(repository, itemId);
                return Page();
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
}
