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
		Task<SmartLockAggregate.SmartLock> GetSmartLockByIdAsync(string id);
		IQueryable<SmartLockAccess> GetAccessesBySmartLockId(string smartLockId);
		IQueryable<SmartLockAccess> GetAccessesByConsumerId(string consumerId);
		Task AddSmartLockAsync(SmartLockAggregate.SmartLock smartLock);
		Task AddSmartLockAccessAsync(SmartLockAccess access);
		void UpdateSmartLock(SmartLockAggregate.SmartLock smartLock);
	}
}
