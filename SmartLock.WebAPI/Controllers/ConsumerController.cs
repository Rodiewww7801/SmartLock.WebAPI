using Microsoft.AspNetCore.Mvc;
using SmartLock.API.Handlers;
using SmartLock.API.Models.RequestModels;
using SmartLock.API.Models.ResponseModels;
using SmartLock.Auth.Models;
using SmartLock.Domain.Factory;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SmartLock.API.Controllers
{
    [Route("api/[controller]")]
	[ApiController]
	public class ConsumerController : ControllerBase
	{
		private readonly IConsumerEventHandler _consumerEventHandler;
		public ConsumerController(IConsumerEventHandler consumerRequestHandler)
		{
			_consumerEventHandler = consumerRequestHandler;
		}

		[HttpPost("CreateConsumer")]
		public async Task<ActionResult<ConsumerResponseModel>> CreateConsumer([FromBody] ConsumerRequestModel model)
		{
			try
			{
				var consumer = await _consumerEventHandler.CreateConsumerEventHandlerAsync(model);
				return CreatedAtAction(nameof(CreateConsumer), consumer);
			} catch (Exception ex) 
			{
				return BadRequest(ex);
			}
		}

		[HttpGet("GetConsumers")]
		public ActionResult<IEnumerable<ConsumerResponseModel>> GetConsumers()
		{
			try
			{
				var consumers = _consumerEventHandler.GetConsumersEventHandler();
				return CreatedAtAction(nameof(GetConsumers), consumers);
			} catch(Exception ex)
			{
				return BadRequest(ex);
			}
		}
	}
}
