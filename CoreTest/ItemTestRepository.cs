﻿using Homebrew5e.Core.DTOs;
using Homebrew5e.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homebrew5e.CoreTest
{
	public class ItemTestRepository : IItemRepository
	{
		private List<ItemDTO> _items;
		public ItemTestRepository(List<ItemDTO> items)
		{
			_items = items;	
		}
		public List<ItemDTO> GetAllItems()
		{
			
			return _items;
		}

		public void AddItem(string name, string attribute, string description, int userID)
		{
			throw new NotImplementedException();
		}

		public List<ItemDTO> GetByUserID(int userID)
		{
			throw new NotImplementedException();
		}

		public int GetAtCreation(string name, string attribute, string description)
		{
			throw new NotImplementedException();
		}

		public ItemDTO GetByID(ItemDTO itemDTO)
		{
			itemDTO.ID = 1;
			itemDTO.UserID = 2;

			return itemDTO;
		}
        public void DeleteItem(int itemID)
		{
			throw new NotImplementedException();
        }
        public void UpdateItem(string name, string attribute, string description, int itemID)
		{
            throw new NotImplementedException();
        }
    }
}
