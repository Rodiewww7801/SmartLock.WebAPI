using SmartLock.Auth.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartLock.Auth.Services
{
	public interface IAuthService
	{
		public Task<TokensDTO> LoginAsync(UserDTO userDTO, SessionDTO sessionDTO);
		public Task RegisterAsync(UserDTO userDTO);
	}
}
