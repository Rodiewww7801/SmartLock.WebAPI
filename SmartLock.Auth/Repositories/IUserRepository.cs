using SmartLock.Auth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartLock.Auth.Repositories
{
	internal interface IUserRepository
	{
		public Task AddUserAsync(User user);
		public void UpdateUser(User user);
		public Task<User?> GetUserByEmailAsync(string email);
	}
}
