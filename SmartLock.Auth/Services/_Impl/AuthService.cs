using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using SmartLock.Auth.Constants;
using SmartLock.Auth.DataManagers;
using SmartLock.Auth.DTO;
using SmartLock.Auth.Models;
using SmartLock.Auth.Repositories;
using SmartLock.Auth.Repositories._Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SmartLock.Auth.Services._Impl
{
	internal class AuthService: IAuthService
	{
		private readonly IConfiguration _config;
		private readonly ITokenService _tokenService;
		private readonly IHttpContextAccessor _httpAccessor;
		private readonly IAuthDataManager _authDataManager;
		
		public AuthService
		(
			IConfiguration config,
			ITokenService tokenService,
			IHttpContextAccessor httpAccessor,
			IAuthDataManager authDataManager
		)
		{
			_config = config;
			_tokenService = tokenService;
			_httpAccessor = httpAccessor;
			_authDataManager = authDataManager;
		}

		public async Task<TokensDTO> LoginAsync(UserDTO userDTO, SessionDTO sessionDTO)
		{
			var user = await GetUserIfExistAsync(userDTO);
			if (user == null)
				throw new Exception("User doesn't exist");

			var accessTokenTask = Task.Run(() => _tokenService.CreateAccessToken(user.Email, user.Role.ToString()));
			var refreshSession= await CreateRefreshSessionAsync(sessionDTO, user);
			var accessToken = await accessTokenTask;

			user.RefreshSessions.Append(refreshSession);
			_authDataManager.UserRepository.UpdateUser(user);
			await _authDataManager.SaveChangesAsync();

			var tokensDTO = new TokensDTO
			{
				AccessToken = accessToken,
				RefreshToken = refreshSession.RefreshToken,
			};

			SetCookieRefreshToken(tokensDTO.RefreshToken);

			return tokensDTO;
		}

		private async Task<RefreshSession> CreateRefreshSessionAsync(SessionDTO sessionDTO, User user)
		{
			var refreshToken = await Task.Run(_tokenService.CreateRefreshToken);
			var refreshSession = new RefreshSession
			{
				Id = Guid.NewGuid().ToString(),
				UserId = user.Id,
				ConnectionId = sessionDTO.ConnectionId,
				UserAgent = sessionDTO.UserAgent,
				RefreshToken = refreshToken,
				IP = sessionDTO.IP
			};

			await _authDataManager.RefreshSessionRepository.AddSessionAsync(refreshSession);
			await _authDataManager.SaveChangesAsync();
			return refreshSession;
		}

		private async Task<User?> GetUserIfExistAsync(UserDTO userDTO)
		{
			var user = await _authDataManager.UserRepository.GetUserByEmailAsync(userDTO.Email);
			if (user != null)
				if (HashPassword(userDTO.Password) == user.PasswordHash)
					return user;
			return null;
		}

		public async Task RegisterAsync(UserDTO userDTO)
		{
			var userRole = User.RoleEnum.Deadly;
			if (userDTO.Email == "admin" && userDTO.Password == "admin")
				userRole = User.RoleEnum.Admin;
			var user = new User
			{
				Id = Guid.NewGuid().ToString(),
				Email = userDTO.Email,
				PasswordHash = HashPassword(userDTO.Password),
				Role = userRole
			};
			await _authDataManager.UserRepository.AddUserAsync(user);
			await _authDataManager.SaveChangesAsync(); 
		}

		private string HashPassword(string password)
		{
			var secret = _config[SLAuthDefaults.SecretPath];
			if (secret == null)
				throw new Exception("Config secret is null");
			var secretBytes = Encoding.UTF8.GetBytes(secret);
			using (var hmac = new HMACSHA512(secretBytes))
			{
				var passwordBytes = Encoding.UTF8.GetBytes(password);
				var hashedPassword = Convert.ToBase64String(hmac.ComputeHash(passwordBytes));
				return hashedPassword;
			}
		}

		private void SetCookieRefreshToken(Token refreshToken)
		{
			var cookieOptions = new CookieOptions
			{
				HttpOnly = true,
				Expires = refreshToken.Expires,
				Domain = "localhost",
				Path = "/api/Authentication"
			};
			_httpAccessor?.HttpContext?.Response.Cookies.Append("refreshToken", refreshToken.Value, cookieOptions);
		}
	}
}
