using SmartLock.Auth.Context;
using SmartLock.Auth.Repositories;
using SmartLock.Auth.Repositories._Impl;
using SmartLock.Domain.DataManager;
using SmartLock.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartLock.Auth.DataManagers._Impl
{
	internal class AuthDataManager : IAuthDataManager
	{
		private readonly AuthDBContext _context;
		private readonly Lazy<IUserRepository> _userRepository;
		private readonly Lazy<IRefreshSessionRepository> _refreshTokenRepository;

		public AuthDataManager(
			AuthDBContext context
		)
		{
			_context = context;
			_userRepository = new Lazy<IUserRepository>(new UserRepository(context));
			_refreshTokenRepository = new Lazy<IRefreshSessionRepository>(new RefreshSessionRepository(context));
		}

		public IUserRepository UserRepository => _userRepository.Value;
		public IRefreshSessionRepository RefreshSessionRepository => _refreshTokenRepository.Value;

		public void SaveChanges()
		{
			_context.SaveChanges();
		}

		public async Task SaveChangesAsync()
		{
			await _context.SaveChangesAsync();
		}
	}
}
