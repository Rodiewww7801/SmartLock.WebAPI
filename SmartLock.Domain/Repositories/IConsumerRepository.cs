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
		Task<Consumer> GetConsumerById(string id);
		Task AddConsumer(Consumer consumer);
		Task UpdateConsumer(Consumer consumer);
	}
}
