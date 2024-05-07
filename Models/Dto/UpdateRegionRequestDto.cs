namespace NZWalks.API.Models.Dto
{
    public class UpdateRegionRequestDto
    {
        public string Code { set; get; }
        public string Name { set; get; }
        public string? RegionImageUrl { set; get; }
    }
}
