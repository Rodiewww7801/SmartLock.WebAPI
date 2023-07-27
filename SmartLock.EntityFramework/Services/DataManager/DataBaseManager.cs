using SmartLock.Domain.Repositories;
using SmartLock.Domain.Services.DataManager;
using SmartLock.EntityFramework.Context;
using SmartLock.EntityFramework.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartLock.EntityFramework.Services.DataManager
{
    public class DataBaseManager : IDataBaseManager
    {
        private readonly SmartLockDBContext _context;
        private readonly Lazy<IConsumerRepository> _consumerRepository;
        private readonly Lazy<ISmartLockRepository> _smartLockRepository;

        public DataBaseManager(
            SmartLockDBContext context
        )
        {
			_context = context;
            _consumerRepository = new Lazy<IConsumerRepository>(new ConsumerRespository(context));
            _smartLockRepository = new Lazy<ISmartLockRepository>(new SmartLockRepository(context));
        }

        public IConsumerRepository ConsumerRepository => _consumerRepository.Value;

        public ISmartLockRepository SmartLockRepository => _smartLockRepository.Value;

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
