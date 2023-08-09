using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SmartLock.Auth.Constants;
using SmartLock.Auth.DTO;
using SmartLock.Auth.Models;
using SmartLock.Auth.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SmartLock.Auth.Services._Impl
{
	internal class TokenService : ITokenService
	{
		private readonly IConfiguration _config;
		private DateTime AccessTokenExpiration => DateTime.UtcNow.AddMinutes(5);
		private DateTime RefreshTokenExpiration => DateTime.UtcNow.AddDays(5);

		public TokenService
		(
			IConfiguration config
		)
		{
			_config = config;
		}

		public Token CreateAccessToken(string userId, string userRole)
		{
			var secret = _config[SLAuthDefaults.SecretPath];
			if (secret == null)
				throw new Exception("Config secret is null");
			var encodedSecret = Encoding.UTF8.GetBytes(secret);
			var claims = new List<Claim>
			{
				new Claim(ClaimTypes.NameIdentifier, userId),
				new Claim(ClaimTypes.Role, userRole)
			};
			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity
				(
					claims: claims,
					authenticationType: SLAuthDefaults.AuthenticationTypeJwt,
					nameType: null,
					roleType: ClaimTypes.Role
				),
				Expires = AccessTokenExpiration,
				SigningCredentials = new SigningCredentials
				(
					new SymmetricSecurityKey(encodedSecret),
					SecurityAlgorithms.HmacSha512Signature
				)
			};
			var tokenHandler = new JwtSecurityTokenHandler();
			var securityToken = tokenHandler.CreateJwtSecurityToken(tokenDescriptor);
			var stringToken = tokenHandler.WriteToken(securityToken);

			var accessToken = new Token
			{
				Value = stringToken,
				Expires = AccessTokenExpiration,
				Created = DateTime.UtcNow,
			};

			return accessToken;
		}

		public Token CreateRefreshToken()
		{
			var stringToken = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));
			var refreshToken = new Token
			{
				Value = stringToken,
				Expires = RefreshTokenExpiration,
				Created = DateTime.UtcNow
			};

			return refreshToken;
		}
	}
}
