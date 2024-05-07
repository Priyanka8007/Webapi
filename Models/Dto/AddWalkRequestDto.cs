namespace NZWalks.API.Models.Dto
{
    public class AddWalkRequestDto
    {
        public string Name { set; get; }

        public string Discription { set; get; }

        public double LengthInKm { get; set; }

        public string? WalkImageUrl { set; get; }
        public Guid DifficultyId { set; get; }
        public Guid RegionId { set; get; }
    }
}
