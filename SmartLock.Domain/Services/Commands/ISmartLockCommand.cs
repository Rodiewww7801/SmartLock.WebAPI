using SmartLock.Domain.Models.SmartLockAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartLock.Domain.Services.Commands
{
    public interface ISmartLockCommand
    {
        public Task AddSmartLockAsync(Models.SmartLockAggregate.SmartLock smartLock);
        public Task AddSmartLockAccessAsync(SmartLockAccess access);
    }
}
