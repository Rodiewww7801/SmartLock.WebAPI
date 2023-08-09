using SmartLock.Auth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartLock.Auth.DTO
{
	public class TokensDTO
	{
		public Token AccessToken { get; set; }
		public Token RefreshToken { get; set; }
	}
}
