using SmartLock.Domain.Models.ConsumerAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartLock.Domain.Repositories
{
    public interface IConsumerRepository
	{
		Task<Consumer> GetConsumerByIdAsync(string id);
		Task AddConsumerAsync(Consumer consumer);
		void UpdateConsumer(Consumer consumer);
		IQueryable<Consumer> GetConsumers();
	}
}
