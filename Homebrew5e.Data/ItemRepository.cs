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

			string query = "SELECT ID, UserID, Name, Attribute, Description FROM Item";

			MySqlCommand command = new MySqlCommand(query, connection);
			MySqlDataReader reader = command.ExecuteReader();

			while (reader.Read())
			{
				ItemDTO item = new ItemDTO
				{
					ID = reader.GetInt32("ID"),
					UserID = reader.GetInt32("UserID"),
					Name = reader.GetString("Name"),
					Attribute = reader.GetString("Attribute"),
					Description = reader.GetString("Description")
				};

				itemDTOs.Add(item);
			}


			connection.Close();

			return itemDTOs;
		}

		public void AddItem(string name, string attribute, string description, int userID)
		{
			using (MySqlConnection connection = new MySqlConnection(_connectionstring))
			{
				connection.Open();

				string query = "INSERT INTO Item (Name, Attribute, Description, UserID) VALUES (@Name, @Attribute, @Description, @UserID)";

				MySqlCommand command = new MySqlCommand(query, connection);

				command.Parameters.AddWithValue("@Name", name);
				command.Parameters.AddWithValue("@Attribute", attribute);
				command.Parameters.AddWithValue("@Description", description);
				command.Parameters.AddWithValue("@UserID", userID);

				command.ExecuteNonQuery();

				connection.Close();
			}


		}

		public int GetAtCreation(string name, string attribute, string description)
		{
			int id = -1;

			MySqlConnection connection = new MySqlConnection(_connectionstring);
			connection.Open();

			string query = "SELECT ID FROM Item WHERE Name=@name AND Attribute=@attribute AND Description=@description";

			using (MySqlCommand command = new MySqlCommand(query, connection))
			{
				command.Parameters.AddWithValue("@name", name);
				command.Parameters.AddWithValue("@attribute", attribute);
				command.Parameters.AddWithValue("@description", description);

				MySqlDataReader reader = command.ExecuteReader();

				while (reader.Read())
				{
					id = reader.GetInt32("ID");
				}

			}
			connection.Close();

			return id;
		}

		public ItemDTO GetByID(ItemDTO itemDTO)
		{
			MySqlConnection connection = new MySqlConnection(_connectionstring);
			connection.Open();

			string query = "SELECT ID, UserID, Name, Attribute, Description FROM Item WHERE ID = @ItemId";

			using (MySqlCommand command = new MySqlCommand(query, connection))
			{
				command.Parameters.AddWithValue("@ItemId", itemDTO.ID);
				MySqlDataReader reader = command.ExecuteReader();
				while (reader.Read())
				{
					itemDTO.ID = reader.GetInt32("ID");
					itemDTO.UserID = reader.GetInt32("UserID");
					itemDTO.Name = reader.GetString("Name");
					itemDTO.Attribute = reader.GetString("Attribute");
					itemDTO.Description = reader.GetString("Description");

				}
			}

			connection.Close();

			return itemDTO;
		}
	}
}



/*command.Parameters.AddWithValue("@UserID", itemDTO.UserID);

			command.Parameters.AddWithValue("@Name", "spear");
			command.Parameters.AddWithValue("@Attribute", "+2 long");
			command.Parameters.AddWithValue("@Description", "it stabs longer");*/