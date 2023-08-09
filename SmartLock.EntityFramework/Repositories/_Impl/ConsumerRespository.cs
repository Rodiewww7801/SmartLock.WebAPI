using Microsoft.EntityFrameworkCore;
using SmartLock.Domain.Models.ConsumerAggregate;
using SmartLock.Domain.Repositories;
using SmartLock.EntityFramework.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartLock.EntityFramework.Repositories._Impl
{
    public class ConsumerRespository : IConsumerRepository
    {
        private readonly SmartLockDBContext _context;
        public ConsumerRespository(SmartLockDBContext context)
        {
            _context = context;
        }

        public async Task AddConsumerAsync(Consumer consumer)
        {
            await _context.Consumers.AddAsync(consumer);
        }

        public async Task<Consumer> GetConsumerByIdAsync(string id)
        {
            return await _context.Consumers.FirstAsync(x => x.Id == id);
        }

        public void UpdateConsumer(Consumer consumer)
        {
            _context.Consumers.Update(consumer);
        }

        public IQueryable<Consumer> GetConsumers()
        {
            return _context.Consumers.AsQueryable();
        }
    }
}
