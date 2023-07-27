using Microsoft.AspNetCore.Mvc;
using SmartLock.API.Models.RequestModels;
using SmartLock.API.Models.ResponseModels;

namespace SmartLock.API.Handlers
{
	public interface IConsumerEventHandler
	{
		public Task<ConsumerResponseModel> CreateConsumerEventHandlerAsync(ConsumerRequestModel model);
		public IEnumerable<ConsumerResponseModel> GetConsumersEventHandler();
	}
}
