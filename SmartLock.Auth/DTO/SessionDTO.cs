using SmartLock.Auth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartLock.Auth.DTO
{
	public class SessionDTO
	{
		public string ConnectionId { get; set; }
		public string UserAgent { get; set; }
		public string IP { get; set; }
	}
}
