using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homebrew5e.Core.Interfaces;
using Homebrew5e.Core.DTOs;
using MySql.Data.MySqlClient;
using System.Configuration;
using Homebrew5e.Core;

namespace Homebrew5e.DAL
{
    public class ItemRepository : IItemRepository
    {
        private string _connectionstring;
        //string connectionstring
        public ItemRepository()
        {
            _connectionstring = "server=127.0.0.1;port=3306;database=homebrew5e;uid=root;pwd=password;";
        }
        public List<ItemDTO> GetAllItems()
        {
            List<ItemDTO> itemDTOs = new List<ItemDTO>();

            MySqlConnection connection = new MySqlConnection(_connectionstring);
            connection.Open();

            string query = "SELECT ID, Name, Attribute, Description FROM Homebrew5e.Item";

            MySqlCommand command = new MySqlCommand(query, connection);
            MySqlDataReader reader = command.ExecuteReader();
            {
                while (reader.Read())
                {
                    ItemDTO item = new ItemDTO
                    {
                        ID = reader.GetInt32("ID"),
                        Name = reader.GetString("Name"),
                        Attribute = reader.GetString("Attribute"),
                        Description = reader.GetString("Description")
                    };

                    itemDTOs.Add(item);
                }
            }

            connection.Close();

            return itemDTOs;
        }

        public void AddItem(ItemDTO itemDTO)
        {
            MySqlConnection connection = new MySqlConnection(_connectionstring);
            connection.Open();

            string query = "INSERT INTO Homebrew5e.Item (Name, Attribute, Description, UserID) VALUES (@Name, @Attribute, @Description, @UserID)";

            MySqlCommand command = new MySqlCommand(query, connection);

            command.Parameters.AddWithValue("@Name", itemDTO.Name);
            command.Parameters.AddWithValue("@Attribute", itemDTO.Attribute);
            command.Parameters.AddWithValue("@Description", itemDTO.Description);
            command.Parameters.AddWithValue("@UserID", 2);

            command.ExecuteNonQuery();

            connection.Close();


        }
    }
}



/*command.Parameters.AddWithValue("@UserID", itemDTO.UserID);

			command.Parameters.AddWithValue("@Name", "spear");
			command.Parameters.AddWithValue("@Attribute", "+2 long");
			command.Parameters.AddWithValue("@Description", "it stabs longer");*/