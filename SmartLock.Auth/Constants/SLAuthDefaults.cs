using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartLock.Auth.Constants
{
	public static class SLAuthDefaults
	{
		public const string AuthenticationTypeJwt = "JWT";
		public const string SecretPath = "Secret";
		public const string AuthDBConnectionPath = "EFAuthConnection";
	}
}
