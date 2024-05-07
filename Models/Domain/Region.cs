namespace NZWalks.API.Models.Domain
{
	public class Region
	{
		public Guid Id { get; set; }
		public string Code { set; get; }
	    public string Name { set; get; }
		public string? RegionImageUrl { set; get; }
	}
}
