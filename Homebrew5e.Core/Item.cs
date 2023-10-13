using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homebrew5e.Core
{
    public class Item
    {
        public string Name { get; set; }
        public string Value { get; set; }

        public Item(string name, string value)
        {
            Name = name;
            Value = value;
        }
        /* //public int Id { get; set; }
         private string Name { get; set; }
         private string Description { get; set; }   

         public Item(string name, string description)
         {
             //Id = id;
             Name = name; 
             Description = description;
         }*/
    }
}
