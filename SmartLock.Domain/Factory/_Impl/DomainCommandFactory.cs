using SmartLock.Domain.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartLock.Domain.Factory._Impl
{
    public class DomainCommandFactory: IDomainCommandFactory
	{
        private readonly Lazy<IConsumerCommand> _consumerCommand;
        private readonly Lazy<ISmartLockCommand> _smartLockCommand;
        public DomainCommandFactory(
			Lazy<IConsumerCommand> consumerCommand,
			Lazy<ISmartLockCommand> smartLockCommand
		)
		{
			_consumerCommand = consumerCommand;
			_smartLockCommand = smartLockCommand;
		}

		public IConsumerCommand ConsumerCommand => _consumerCommand.Value;
		public ISmartLockCommand SmartLockCommand => _smartLockCommand.Value;
	}
}
