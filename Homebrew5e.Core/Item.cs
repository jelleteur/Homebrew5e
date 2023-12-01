using Homebrew5e.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homebrew5e.Core
{
    public class Item
    {
        private string Name { get; set; }
        private string Description { get; set; }
        private string Attribute { get; set; }

        public Item() { }
        public Item(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public string GetItemName()
        {
            return Name;
        }

        public string GetItemDescription()
        {
            return Description;
        }

        public string GetItemAttribute()
        {
            return Attribute;
        }

        public List<Item> GetAllItems()
        {
            string FilePath = "..\\Item.txt";
            List<Item> items = new List<Item>();


            //lees textfile
            string[] lines = File.ReadAllLines(FilePath);

            foreach (var line in lines)
            {
                //split lijnen tekst
                string[] fields = line.Split(',');

                //voeg items toe aan lijst
                items.Add(new Item(fields[0], fields[1]));
            }
        }
    }
}

