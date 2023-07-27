using SmartLock.Domain.Models.ConsumerAggregate;
using SmartLock.Domain.Services.Commands;
using SmartLock.Domain.Services.DataManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartLock.Domain.Services.Commands._Impl
{
    internal class ConsumerCommand : IConsumerCommand
    {
        private readonly Lazy<IDataBaseManager> _dataManager;
        private IDataBaseManager DataManager => _dataManager.Value;
        public ConsumerCommand(Lazy<IDataBaseManager> dataManager)
        {
            _dataManager = dataManager;
        }

        public async Task AddConsumerAsync(Consumer consumer)
        {
            consumer.Id = Guid.NewGuid().ToString();
            await DataManager.ConsumerRepository.AddConsumerAsync(consumer);
            await DataManager.SaveChangesAsync();
        }

        public IQueryable<Consumer> GetConsumers()
        {
            return DataManager.ConsumerRepository.GetConsumers();
        }
    }
}
