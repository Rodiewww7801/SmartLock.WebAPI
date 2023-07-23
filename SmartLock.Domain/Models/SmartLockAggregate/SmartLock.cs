using SmartLock.Domain.Models.SmartLockAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartLock.Domain.Models.SmartLockAggregate
{
	public class SmartLock
	{
		public string Id { get; set; }
		public string? Name { get; set; }
		public string? Description { get; set; }
		public List<SmartLockAccess> SmartLockAccesses { get; set; }
	}
}
