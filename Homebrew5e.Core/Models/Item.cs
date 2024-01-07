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
        private int UserID { get; set; }

        public Item() { }
        public Item(ItemDTO dto)
        {
            ID = dto.ID;
            Name = dto.Name;
            Description = dto.Description;
            Attribute = dto.Attribute;
            UserID = dto.UserID;
        }

        public int GetID() { return ID; }
        public int GetUserID() { return UserID; }
        public string GetName() { return Name; }
        public string GetDescription() { return Description; }
        public string GetAttribute() { return Attribute; }

        public string GetAttributeForUpdate()
        {
            string[] splitAttribute = Attribute.Split(' ');

            return splitAttribute[0];
        }

        public Item GetByID(IItemRepository repository, int id)
        {
            ItemDTO itemDTO = new ItemDTO();
            itemDTO.ID = id;

            repository.GetByID(itemDTO);

            return new Item(itemDTO);
        }

        public List<Item> GetByUserID(IItemRepository repository, int id)
        {
            List<ItemDTO> itemDTOs = new List<ItemDTO>();
            List<Item> items = new List<Item>();


            itemDTOs = repository.GetByUserID(id);

            foreach (ItemDTO dto in itemDTOs)
            {
                items.Add(new Item(dto));
            }

            return items;
        }

        public void Delete(IItemRepository repository, int id)
        {
            repository.DeleteItem(id);
        }

        public void Update(IItemRepository repository, string name, string attribute, string description, int id)
        {
            repository.UpdateItem(name, attribute, description, id);
        }
    }
}