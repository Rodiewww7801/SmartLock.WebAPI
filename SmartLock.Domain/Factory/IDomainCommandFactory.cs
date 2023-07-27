using SmartLock.Domain.Services.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartLock.Domain.Factory
{
    public interface IDomainCommandFactory
	{
		public IConsumerCommand ConsumerCommand { get; }
		public ISmartLockCommand SmartLockCommand { get; }
	}
}
