namespace NZWalks.API.Models.Dto
{
    public class AddRegionRequestDto
    {
        public string Code { set; get; }
        public string Name { set; get; }
        public string? RegionImageUrl { set; get; }
    }
}
