namespace RentACar.Models.Dto
{
    public record CarBrandListDto
    {
        public int Id { get; set; }
        public string CarBrands { get; init; }
        public string Image { get; init; }
    }
}
