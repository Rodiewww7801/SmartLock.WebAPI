using SmartLock.Auth.Repositories;
using SmartLock.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartLock.Auth.DataManagers
{
	internal interface IAuthDataManager
	{
		public IUserRepository UserRepository { get; }
		public IRefreshSessionRepository RefreshSessionRepository { get; }
		public void SaveChanges();
		public Task SaveChangesAsync();
	}
}
