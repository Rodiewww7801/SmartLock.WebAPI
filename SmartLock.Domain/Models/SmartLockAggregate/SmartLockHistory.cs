using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceDetection.Domain.Entities.SmartLockAggregate
{
	public class SmartLockHistory
	{
		public string Id { get; set; }
		public string SmartLockId { get; set; }
		public string UserId { get; set; }
		public DateTime Timestamp { get; set; }
	}
}
