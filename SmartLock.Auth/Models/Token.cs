using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartLock.Auth.Models
{
	public class Token
	{
		public string Value { get; set; }
		public DateTime Created { get;set; }
		public DateTime Expires { get;set; }
	}
}
