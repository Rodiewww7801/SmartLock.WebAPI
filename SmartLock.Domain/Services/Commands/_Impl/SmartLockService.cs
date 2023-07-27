using SmartLock.Domain.Models.SmartLockAggregate;
using SmartLock.Domain.Services.Commands;
using SmartLock.Domain.Services.DataManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartLockAggregate = SmartLock.Domain.Models.SmartLockAggregate;

namespace SmartLock.Domain.Services.Commands._Impl
{
    public class SmartLockService : ISmartLockCommand
    {
        private readonly Lazy<IDataBaseManager> _dataManager;
        private IDataBaseManager DataManager => _dataManager.Value;
        public SmartLockService(Lazy<IDataBaseManager> dataManager)
        {
            _dataManager = dataManager;
        }

        public async Task AddSmartLockAccessAsync(SmartLockAccess access)
        {
            access.Id = Guid.NewGuid().ToString();
            await DataManager.SmartLockRepository.AddSmartLockAccessAsync(access);
            await DataManager.SaveChangesAsync();
        }

        public async Task AddSmartLockAsync(SmartLockAggregate.SmartLock smartLock)
        {
            smartLock.Id = Guid.NewGuid().ToString();
            await DataManager.SmartLockRepository.AddSmartLockAsync(smartLock);
            await DataManager.SaveChangesAsync();
        }
    }
}
