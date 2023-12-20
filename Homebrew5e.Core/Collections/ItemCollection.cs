﻿using Homebrew5e.Core.DTOs;
using Homebrew5e.Core.Interfaces;
using Homebrew5e.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homebrew5e.Core.Collections
{
    public class ItemCollection
    {
        private IItemRepository _ItemRepository;

        public ItemCollection(IItemRepository _IItemRepository)
        {
            _ItemRepository = _IItemRepository;
        }

        public List<Item> GetAllItems()
        {
            List<ItemDTO> itemDTOs = new List<ItemDTO>();
            List<Item> items = new List<Item>();


            itemDTOs = _ItemRepository.GetAllItems();

            foreach (ItemDTO itemDTO in itemDTOs)
            {
                items.Add(new Item(itemDTO));
            }
            return items;
        }

        public int CreateItemProcess(string name, string attribute, string description)
        {
            _ItemRepository.AddItem(name, attribute, description);

            int id;
            id = _ItemRepository.GetAtCreation(name, attribute, description);
            return id;
        }
    }
}
