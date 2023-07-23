using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartLock.Domain.Models.ConsumerFaceAggregate
{
    public class ConsumerFace
    {
		public enum TypeOfUsingEnum {
			Avatar,
			Training
		}
        public string Id { get; set; }
        public byte[] Image { get; set; }
        public string ConsumerId { get; set; }
		public TypeOfUsingEnum TypeOfUsing { get; set; }
    }
}
