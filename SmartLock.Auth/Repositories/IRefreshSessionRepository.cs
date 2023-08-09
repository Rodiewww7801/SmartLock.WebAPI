using Microsoft.EntityFrameworkCore;
using SmartLock.Auth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartLock.Auth.Repositories
{
	internal interface IRefreshSessionRepository
	{
		public Task AddSessionAsync(RefreshSession refreshSession);

		public IQueryable<RefreshSession> GetSessionsByToken(string refreshToken);
		public IQueryable<RefreshSession> GetSessionByToken(string refreshToken);
		public void DeleteSessionByToken(string refreshToken);
	}
}
