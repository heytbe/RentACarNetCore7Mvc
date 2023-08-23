namespace RentACar.Models.Dto
{
    public record ImageUploadDto
    {
        public string ImageName { get; init; }
        public string ImagePath { get; init; }
        public decimal ImageSize { get; init; }
    }
}
