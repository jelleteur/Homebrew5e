using Homebrew5e.Core;
using Homebrew5e.Core.Collections;
using Homebrew5e.Core.Enums;
using Homebrew5e.Core.DTOs;
using Homebrew5e.Core.Interfaces;
using Homebrew5e.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Homebrew5e.App.Pages
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



        public void OnPost()
        {
            ItemDTO newItem = new ItemDTO
            {
                Name = itemName,
                Attribute = itemAttribute + itemAttributeEnum.ToString(),
                Description = itemDescription
            };
            _itemCollection.CreateItem(newItem);
        }
    }
}
