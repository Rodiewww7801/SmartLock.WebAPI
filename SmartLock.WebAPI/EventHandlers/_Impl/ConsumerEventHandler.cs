using SmartLock.API.Models.RequestModels;
using SmartLock.API.Models.ResponseModels;
using SmartLock.Domain.Factory;

namespace SmartLock.API.Handlers._Impl
{
    public class ConsumerEventHandler: IConsumerEventHandler
    {
        private readonly IDomainCommandFactory _commandFactory;
        public ConsumerEventHandler(IDomainCommandFactory serviceFactory)
        {
			_commandFactory = serviceFactory;
        }

		public async Task<ConsumerResponseModel> CreateConsumerEventHandlerAsync(ConsumerRequestModel model)
		{
			var consumer = model.ToDomainModel();
			var command = _commandFactory.ConsumerCommand;
			await command.AddConsumerAsync(consumer);
			return new ConsumerResponseModel(consumer);
		}

		public IEnumerable<ConsumerResponseModel> GetConsumersEventHandler()
		{
			var command = _commandFactory.ConsumerCommand;
			var consumers = command.GetConsumers().Select(x => new ConsumerResponseModel(x)).ToList();
			return consumers;
		}
	}
}
