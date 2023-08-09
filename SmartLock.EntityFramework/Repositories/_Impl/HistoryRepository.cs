using Microsoft.EntityFrameworkCore.Migrations;
using SmartLock.Domain.Models.HistoryAggreagate;
using SmartLock.EntityFramework.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartLock.EntityFramework.Repositories._Impl
{
    public class HistoryRepository : Domain.Repositories.IHistoryRepository
    {
        private readonly SmartLockDBContext _context;
        public HistoryRepository(SmartLockDBContext context)
        {
            _context = context;
        }
        public async Task AddHistoryAsync(SmartLockConsumerHistory history)
        {
            await _context.SmartLockConsumerHistories.AddAsync(history);
        }

        public IQueryable<SmartLockConsumerHistory> GetHistoriesByConsumerId(string consumerId)
        {
            return _context.SmartLockConsumerHistories.Where(x => x.ConsumerId == consumerId);
        }

        public IQueryable<SmartLockConsumerHistory> GetHistoriesBySmartLockId(string smartLockId)
        {
            return _context.SmartLockConsumerHistories.Where(x => x.SmartLockId == smartLockId);
        }
    }
}
