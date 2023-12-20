namespace Homebrew5e.Core.Models
{
	public class DnDUser
	{
		private int ID { get; set; }
		private string Username { get; set; }
		private string Email { get; set; }
		private string Password { get; set; }

		public DnDUser()
		{

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
	}
}