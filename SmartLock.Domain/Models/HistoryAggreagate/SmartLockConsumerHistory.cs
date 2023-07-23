using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartLock.Domain.Models.HistoryAggreagate
{
    public class SmartLockConsumerHistory
    {
        public string Id { get; set; }
        public string SmartLockId { get; set; }
        public string ConsumerId { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
