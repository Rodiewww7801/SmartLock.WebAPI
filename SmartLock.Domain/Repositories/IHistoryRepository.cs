using SmartLock.Domain.Models.HistoryAggreagate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartLock.Domain.Repositories
{
	public interface IHistoryRepository
	{
		Task<IQueryable<SmartLockConsumerHistory>> GetHistoriesByConsumerId(string consumerId);
		Task<IQueryable<SmartLockConsumerHistory>> GetHistoriesBySmartLockId(string smartLockId);
		Task AddHistory(SmartLockConsumerHistory history);
	}
}
