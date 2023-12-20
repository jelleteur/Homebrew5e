using Homebrew5e.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homebrew5e.Core.Collections
{
	public class DnDUserCollection
	{
		private IDnDUserRepository UserRepository;
		public DnDUserCollection(IDnDUserRepository repository)
		{
			UserRepository = repository;
		}

		public int CreateUser(string username, string password, string email)
		{
			UserRepository.CreateUser(username, password, email);
			
			return LoginUser(email, password);
		}

		public int LoginUser(string email, string password)
		{
			int id = UserRepository.LoginUser(email, password);

			return id;
		}
	}
}
