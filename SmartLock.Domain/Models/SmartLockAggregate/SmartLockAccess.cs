using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartLock.Domain.Models.SmartLockAggregate
{
	public class SmartLockAccess
	{
		public enum AccessStateEnum
		{
			Denied,
			Allowed
		}

		public string Id { get; set; }
		public string ConsumerId { get; set; }
		public string SmartLockId { get; set; }
		public DateTime DateOfIssue { get; set; }
		public AccessStateEnum AccessState { get; set; }
	}
}
