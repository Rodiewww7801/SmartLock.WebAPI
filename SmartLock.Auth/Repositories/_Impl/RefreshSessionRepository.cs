using SmartLock.Auth.Context;
using SmartLock.Auth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartLock.Auth.Repositories._Impl
{
	internal class RefreshSessionRepository: IRefreshSessionRepository
	{
		private readonly AuthDBContext _dbContext;
		public RefreshSessionRepository(AuthDBContext dbContext) 
		{
			_dbContext = dbContext;
		} 
		public async Task AddSessionAsync(RefreshSession refreshSession)
		{
			await _dbContext.RefreshSessions.AddAsync(refreshSession);
		}

		public IQueryable<RefreshSession> GetSessionsByToken(string refreshToken)
		{
			return _dbContext.RefreshSessions.Where(session => session.RefreshToken.Value == refreshToken);
		}

		public IQueryable<RefreshSession> GetSessionByToken(string refreshToken)
		{
			return _dbContext.RefreshSessions.Where(session => session.RefreshToken.Value == refreshToken);
		}

		public void DeleteSessionByToken(string refreshToken)
		{
			var sessions = GetSessionByToken(refreshToken);
			_dbContext.RefreshSessions.RemoveRange(sessions);
		}
	}
}
