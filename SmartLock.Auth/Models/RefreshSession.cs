using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartLock.Auth.Models
{
	public class RefreshSession
	{
		public string Id { get; set; }
		public string ConnectionId { get; set; }
		public string UserId { get; set; }
		public Token RefreshToken { get; set; }
		public string UserAgent { get; set; }
		public string IP { get; set; }
	}
}
