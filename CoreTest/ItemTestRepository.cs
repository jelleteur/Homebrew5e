using Homebrew5e.Core.DTOs;
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
		private string _connectionstring;
		private List<ItemDTO> _items;

		//string connectionstring
		public ItemTestRepository(List<ItemDTO> items)
		{
			_items = items;	
		}
		public List<ItemDTO> GetAllItems()
		{
			
			return _items;
		}

		public void AddItem(string name, string attribute, string description)
		{
			
		}

		public int GetAtCreation(string name, string attribute, string description)
		{
			int IDint = 5;

			return IDint;
		}

		public ItemDTO GetByID(ItemDTO itemDTO)
		{
			itemDTO.ID = 1;
			itemDTO.UserID = 2;

			return itemDTO;
		}
	}
}
