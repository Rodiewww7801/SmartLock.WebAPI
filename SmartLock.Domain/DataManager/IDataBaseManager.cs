using SmartLock.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartLock.Domain.DataManager
{
    public interface IDataBaseManager
    {
        public IConsumerRepository ConsumerRepository { get; }
        public ISmartLockRepository SmartLockRepository { get; }
        public void SaveChanges();
        public Task SaveChangesAsync();
    }
}
