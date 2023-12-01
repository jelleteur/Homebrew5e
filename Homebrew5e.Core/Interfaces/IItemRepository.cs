using Homebrew5e.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homebrew5e.Core.Interfaces
{
	public interface IItemRepository
	{
		public List<ItemDTO> GetAllItems();
		public void AddItem(ItemDTO itemDTO);
	}
}
