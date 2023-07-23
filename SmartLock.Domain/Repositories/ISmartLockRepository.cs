using SmartLockAggregate = SmartLock.Domain.Models.SmartLockAggregate;
using SmartLock.Domain.Models.SmartLockAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartLock.Domain.Repositories
{
	public interface ISmartLockRepository
	{
		Task<SmartLockAggregate.SmartLock> GetSmartLockById(string id);
		Task<IQueryable<SmartLockAccess>> GetAccessesBySmartLockId(string smartLockId);
		Task<IQueryable<SmartLockAccess>> GetAccessesByConsumerId(string consumerId);
		Task AddSmartLock(SmartLockAggregate.SmartLock smartLock);
		Task UpdateSmartLock(SmartLockAggregate.SmartLock smartLock);
	}
}
