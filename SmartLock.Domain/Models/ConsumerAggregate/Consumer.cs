using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceDetection.Domain.Entities.ConsumerAggregate
{
	public class Consumer
	{
		public enum SecurityLevelEnum 
		{
			Administrator,
			Default
		}
		public string Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string MiddleName { get; set; }
		public SecurityLevelEnum SecurityLevel { get; set; }
		public List<ConsumerFace> ConsumerFaces { get; set; }
	}
}
