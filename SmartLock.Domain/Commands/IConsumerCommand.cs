using SmartLock.Domain.Models.ConsumerAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartLock.Domain.Commands
{
    public interface IConsumerCommand
    {
        public Task AddConsumerAsync(Consumer consumer);
        public IQueryable<Consumer> GetConsumers();
    }
}
