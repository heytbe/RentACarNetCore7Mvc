using Microsoft.AspNetCore.Http;

namespace RentACar.Models.Dto
{
    public record CarBrandCreateDto
    {

        public string CarBrands { get; init; }
        public IFormFile Image { get; init; }
    }
}
