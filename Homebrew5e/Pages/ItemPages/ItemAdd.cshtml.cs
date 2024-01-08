using Homebrew5e.Core;
using Homebrew5e.Core.Collections;
using Homebrew5e.Core.Enums;
using Homebrew5e.Core.DTOs;
using Homebrew5e.Core.Interfaces;
using Homebrew5e.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using System.Dynamic;

namespace Homebrew5e.App.Pages.ItemPages
{
    public class ItemAddModel : PageModel
    {
        private readonly ItemCollection _itemCollection;

        public ItemAddModel(ItemCollection itemCollection)
        {
            _itemCollection = itemCollection;

        }

        [BindProperty]
        public string itemName { get; set; }
        [BindProperty]
        public string itemAttribute { get; set; }
        [BindProperty]
        public string itemAttributeEnum { get; set; }
        [BindProperty]
        public string itemDescription { get; set; }
        [BindProperty]
        public int userID { get; set; }

        public IActionResult OnGet()
        {
            string userIdCookieValue = HttpContext.Request.Cookies["Homebrew5e.UserId"];

            if (userIdCookieValue != null)
            {
                Response.Cookies.Append("Homebrew5e.UserId", userIdCookieValue, new CookieOptions
                {
                    Expires = DateTimeOffset.Now.AddMinutes(20)
                });
                userID = int.Parse(userIdCookieValue);
                return Page();
            }
            else
            {
                return Redirect($"/Index");
            }
        }

        public IActionResult OnPost()
        {
            string name = itemName;
            string attribute = itemAttribute + " " + itemAttributeEnum.ToString();
            string description = itemDescription;
            userID = int.Parse(HttpContext.Request.Cookies["Homebrew5e.UserId"]);
            int falseID = -1;
            int id;


            id = _itemCollection.CreateItemProcess(name, attribute, description, userID);
            if (id != falseID)
            {
                return Redirect($"/ItemPages/ItemInfo?id={id}");
            }
            else
            {
                return Redirect($"/Error");
            }
        }
    }
}
