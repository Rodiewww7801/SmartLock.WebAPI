using SmartLock.Domain.Models.ConsumerAggregate;

namespace SmartLock.API.Models.ResponseModels
{
	public class ConsumerResponseModel
	{
		public string Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string MiddleName { get; set; }
		public string SecurityLevel { get; set; }

		public ConsumerResponseModel(Consumer consumer) {
			Id = consumer.Id;
			FirstName = consumer.FirstName;
			LastName = consumer.LastName;
			MiddleName = consumer.MiddleName;
			SecurityLevel = consumer.SecurityLevel.ToString();
		}
	}
}
