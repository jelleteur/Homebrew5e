﻿using Homebrew5e.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Homebrew5e.Core.Interfaces
{
	public interface IItemRepository
	{
		public List<ItemDTO> GetAllItems();
		public void AddItem(string name, string attribute, string description);
		public ItemDTO GetByID(ItemDTO itemDTO);
		public int GetAtCreation(string name, string attribute, string description);
	}
}
