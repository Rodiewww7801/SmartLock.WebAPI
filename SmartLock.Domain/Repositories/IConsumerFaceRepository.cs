using SmartLock.Domain.Models.ConsumerFaceAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartLock.Domain.Repositories
{
	public interface IConsumerFaceRepositories
	{
		Task<IQueryable<ConsumerFace>> GetConsumerFacesByConsumerId(string consumerId);
		Task<string> GetConsumerIdByFace(byte[] face);
		Task AddConsumerFace(ConsumerFace consumerFace);
	}
}
