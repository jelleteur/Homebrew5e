using Homebrew5e.Core;
using Homebrew5e.Core.Collections;
using Homebrew5e.Core.Interfaces;
using Homebrew5e.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

// new ItemCollectionModel(...)

namespace Homebrew5e.App.Pages
{
    public class ItemTableModel : PageModel
    {
        
        private readonly ItemCollection _itemCollection;

        public ItemTableModel(ItemCollection itemCollection)
        {
            _itemCollection = itemCollection;

        }

        public List<Item> Items { get; private set; }

        public void OnGet()
        {
            Items = _itemCollection.GetAllItems();
        }
    }
}
