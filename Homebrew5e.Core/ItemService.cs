using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homebrew5e.Core
{
    public class ItemService
    {
        private List<Item> itemList = new List<Item>() { new Item("sword", "5")};

        /*// Constructor to initialize with hardcoded items
        public ItemService()
        {
            // Hardcoded items using the constructor
            itemList.Add(new Item("Apple", "5"));
            itemList.Add(new Item("Sword", "6"));
        }*/

        public void AddItem(Item item)
        {
            itemList.Add(item);
        }

        public List<Item> GetAllItems()
        {
            return itemList;
        }
    }
}
