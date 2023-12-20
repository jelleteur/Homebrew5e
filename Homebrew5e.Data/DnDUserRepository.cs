using Homebrew5e.Core.Interfaces;
using Homebrew5e.Core.DTOs;
using Homebrew5e.Core.Collections;
using MySql.Data.MySqlClient;
using System.Xml.Linq;

namespace Homebrew5e.Dal
{
	public class DnDUserRepository : IDnDUserRepository
	{
		private string _connectionstring;
		public DnDUserRepository()
		{
			_connectionstring = "server=127.0.0.1;port=3306;database=homebrew5e;uid=root;pwd=password;";
		}

		public void CreateUser(string username, string password, string email)
		{
			using (MySqlConnection connection = new MySqlConnection(_connectionstring))
			{
				connection.Open();

				string query = "INSERT INTO user (Username, Email, Password) VALUES (@Username, @Email, @Password)";

				MySqlCommand command = new MySqlCommand(query, connection);

				command.Parameters.AddWithValue("@Username", username);
				command.Parameters.AddWithValue("@Email", email);
				command.Parameters.AddWithValue("@Password", password);

				command.ExecuteNonQuery();

				connection.Close();
			}
		}

		public int LoginUser(string email, string password)
		{
			int id = -1;

			using (MySqlConnection connection = new MySqlConnection(_connectionstring))
			{
				connection.Open();

				string query = "SELECT ID FROM User WHERE Email=@Email AND Password=@Password";

				using (MySqlCommand command = new MySqlCommand(query, connection))
				{
					command.Parameters.AddWithValue("@Email", email);
					command.Parameters.AddWithValue("@Password", password);

					MySqlDataReader reader = command.ExecuteReader();

					while (reader.Read())
					{
						id = reader.GetInt32("ID");
					}

				}
				connection.Close();
			}

			return id;

		}
	}
}