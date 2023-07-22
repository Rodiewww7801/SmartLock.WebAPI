using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceDetection.Domain.Entities.ConsumerAggregate
{
	public class ConsumerFace
	{
		public string Id { get; set; }
		public byte[] Image { get; set; }
		public string UserId { get; set; }
		public Consumer Consumer { get; set; }
	}
}
