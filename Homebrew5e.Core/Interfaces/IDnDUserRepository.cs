using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homebrew5e.Core.Interfaces
{
	public interface IDnDUserRepository
	{
		public void CreateUser(string username, string password, string email);
		public int LoginUser(string email, string password);
		public bool CheckDuplicate(string email, string username);


    }
}
