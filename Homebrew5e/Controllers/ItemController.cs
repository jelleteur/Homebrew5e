using Microsoft.AspNetCore.Mvc;
using Homebrew5e.Core;

namespace Homebrew5e.App.Controllers
{
    public class ItemController : Controller
    {
        private readonly ItemService _itemService;

        public ItemController(ItemService itemService)
        {
            _itemService = itemService;
        }

        public IActionResult Index()
        {
            var items = _itemService.GetAllItems();
            return View(items);
        }
    }
}
