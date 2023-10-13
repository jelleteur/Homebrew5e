using Homebrew5e.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Homebrew5e.App.Pages
{
    public class ItemModel : PageModel
    {
        private readonly ItemService _itemService;

        public ItemModel(ItemService itemService)
        {
            _itemService = itemService;
        }

        public List<Item> Items { get; private set; }

        public void OnGet()
        {
            Items = _itemService.GetAllItems();
        }
    }
}
