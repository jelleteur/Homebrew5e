using Homebrew5e.Core.DTOs;
using Homebrew5e.Core.Interfaces;
using Homebrew5e.Core.Collections;
using System.Net.Http.Headers;

namespace Homebrew5e.Core
{
	public class Item
	{
		private int ID { get; set; }
		private string Name { get; set; }
		private string Description { get; set; }
		private string Attribute { get; set; }

		
		public Item() { }
		public Item(string name, string description, string attribute)
		{
			Name = name;
			Description = description;
			Attribute = attribute;
		}

		internal Item(ItemDTO dto)
		{
			ID = dto.ID;
			Name = dto.Name;
			Description = dto.Description;
			Attribute = dto.Attribute;
		}

		public int GetID()
		{
			return ID;
		}

		public string GetName()
		{
			return Name;
		}

		public string GetDescription()
		{
			return Description;
		}

		public string GetAttribute()
		{
			return Attribute;
		}

		
	}
}