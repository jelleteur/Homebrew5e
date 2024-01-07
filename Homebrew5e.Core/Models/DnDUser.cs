using Homebrew5e.Core.Interfaces;

namespace Homebrew5e.Core.Models
{
	public class DnDUser
	{
		private int ID { get; set; }
		private string Username { get; set; }
		private string Email { get; set; }
		private string Password { get; set; }

		public DnDUser(int id, string username, string email)
		{
			ID = id;
			Username = username;
			Email = email;
		}
		
		public int GetID()
		{
			return ID;
		}

		public string GetUsername()
		{
			return Username;
		}

		public string GetEmail()
		{
			return Email;
		}

		public void UpdateDnDUser(IDnDUserRepository repository ,int id, string username, string email, string password)
		{

		}
	}
}