using Microsoft.EntityFrameworkCore;
using SmartLock.Domain.Models.SmartLockAggregate;
using SmartLock.Domain.Repositories;
using SmartLock.EntityFramework.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartLock.EntityFramework.Repositories
{
    public class SmartLockRepository : ISmartLockRepository
    {
        private readonly SmartLockDBContext _context;
        public SmartLockRepository(SmartLockDBContext context)
        {
            _context = context;
        }

        public async Task AddSmartLockAccessAsync(SmartLockAccess access)
        {
            await _context.SmartLockAccesses.AddAsync(access);
        }

        public async Task AddSmartLockAsync(Domain.Models.SmartLockAggregate.SmartLock smartLock)
        {
            await _context.SmartLocks.AddAsync(smartLock);
        }

        public IQueryable<SmartLockAccess> GetAccessesByConsumerId(string consumerId)
        {
            return _context.SmartLockAccesses.Where(x => x.ConsumerId == consumerId);
        }

        public IQueryable<SmartLockAccess> GetAccessesBySmartLockId(string smartLockId)
        {
            return _context.SmartLockAccesses.Where(x => x.SmartLockId == smartLockId);
        }

        public async Task<Domain.Models.SmartLockAggregate.SmartLock> GetSmartLockByIdAsync(string id)
        {
            return await _context.SmartLocks.FirstAsync(x => x.Id == id);
        }

        public void UpdateSmartLock(Domain.Models.SmartLockAggregate.SmartLock smartLock)
        {
            _context.SmartLocks.Update(smartLock);
        }
    }
}
