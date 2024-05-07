using System.Reflection.Metadata;

namespace NZWalks.API.Models.Domain
{
	public class Walk
	{
		public Guid Id { set; get;}
		public string Name { set; get; }
		public string Discription { set; get; }

		public double LengthInKm { get; set; }

		public string? WalkImageUrl { set; get; }
		public Guid DifficultyId { set; get; }
		public Guid RegionId { set; get; }

		//Navigation Properties

		public Difficulty Difficulty { get; set; }
		public Region Region { get; set; }
		

	}
}
