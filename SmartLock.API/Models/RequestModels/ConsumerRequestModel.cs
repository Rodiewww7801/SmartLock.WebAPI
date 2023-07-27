using SmartLock.Domain.Models.ConsumerAggregate;

namespace SmartLock.API.Models.RequestModels
{
	public class ConsumerRequestModel
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string MiddleName { get; set; }
		public string SecurityLevel { get; set; }

		public Consumer ToDomainModel()
		{
			try
			{
				return new Consumer
				{
					Id = null,
					FirstName = FirstName,
					LastName = LastName,
					MiddleName = MiddleName,
					SecurityLevel = Enum.Parse<Consumer.SecurityLevelEnum>(this.SecurityLevel)
				};
			} catch
			{
				throw;
			}
		}
	}
}
