using Microsoft.EntityFrameworkCore;
using SmartLock.Domain.Models.ConsumerFaceAggregate;
using SmartLock.Domain.Repositories;
using SmartLock.EntityFramework.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartLock.EntityFramework.Context;

namespace SmartLock.EntityFramework.Repositories
{
    public class ConsumerFaceRepository : IConsumerFaceRepository
    {
        private readonly SmartLockDBContext _dbContext;
        public ConsumerFaceRepository(SmartLockDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddConsumerFaceAsync(ConsumerFace consumerFace)
        {
            await _dbContext.ConsumerFaces.AddAsync(consumerFace);
        }

        public IQueryable<ConsumerFace> GetConsumerFacesByConsumerId(string consumerId)
        {
            return _dbContext.ConsumerFaces.Where(x => x.ConsumerId == consumerId);
        }
    }
}
