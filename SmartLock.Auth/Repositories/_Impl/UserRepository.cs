using Microsoft.EntityFrameworkCore;
using SmartLock.Auth.Context;
using SmartLock.Auth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartLock.Auth.Repositories._Impl
{
	internal class UserRepository: IUserRepository
	{
		private readonly AuthDBContext _dbContext;
		public UserRepository(AuthDBContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task AddUserAsync(User user)
		{
			var userExist = await GetUserByEmailAsync(user.Email);
			if (userExist != null)
				throw new Exception("User with same email already exist");
			await _dbContext.Users.AddAsync(user);
		}

		public async Task<User?> GetUserByEmailAsync(string email)
		{
			return await _dbContext.Users.FirstOrDefaultAsync( user => user.Email == email);
		}

		public void  UpdateUser(User user)
		{
			_dbContext.Users.Update(user);
		}
	}
}
