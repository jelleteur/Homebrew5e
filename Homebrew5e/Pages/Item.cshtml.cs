using Homebrew5e.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Homebrew5e.App.Pages
{
    public class ItemModel : PageModel
    {
        private readonly Item _item;

        public ItemModel(Item item)
        {
            _item = item;
        }

        public List<Item> Items { get; private set; }

        public void OnGet()
        {
            Items = _item.GetAllItems();
        }
    }
}
