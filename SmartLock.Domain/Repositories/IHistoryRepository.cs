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
		IQueryable<SmartLockConsumerHistory> GetHistoriesByConsumerId(string consumerId);
		IQueryable<SmartLockConsumerHistory> GetHistoriesBySmartLockId(string smartLockId);
		Task AddHistoryAsync(SmartLockConsumerHistory history);
	}
}
