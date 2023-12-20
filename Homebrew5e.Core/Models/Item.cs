using Homebrew5e.Core.DTOs;
using Homebrew5e.Core.Interfaces;
using Homebrew5e.Core.Collections;
using System.Net.Http.Headers;

namespace Homebrew5e.Core.Models
{
    public class Item
    {
        private int ID { get; set; }
        private string Name { get; set; }
        private string Description { get; set; }
        private string Attribute { get; set; }

        public Item() { }
        public Item(ItemDTO dto)
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

        public Item GetByID(IItemRepository repository, int id)
        {
            ItemDTO itemDTO = new ItemDTO();
            itemDTO.ID = id;

            repository.GetByID(itemDTO);

            return new Item(itemDTO);
        }


    }
}