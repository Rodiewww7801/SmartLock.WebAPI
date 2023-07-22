namespace FaceDetection.Domain.Entities.SmartLockAggregate
{
	public class SmartLock
	{
		public string Id { get; set; }
		public string? Name { get; set; }
		public string? Description { get; set; }
		public List<SmartLockUserAccess> UserAccesses { get; set; } 
	}
}
