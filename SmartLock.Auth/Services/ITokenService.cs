using SmartLock.Auth.DTO;
using SmartLock.Auth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartLock.Auth.Services
{
	internal interface ITokenService
	{
		public Token CreateRefreshToken();
		public Token CreateAccessToken(string userId, string userRole);
	}
}
