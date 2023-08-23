using Microsoft.AspNetCore.Http;

namespace RentACar.Models.Dto
{
    public record CarCreateDto
    {
        public string Model { get; set; }
        public IFormFile CarImage { get; set; }
        public string CarDate { get; init; }
        public int CarPersons { get; init; }
        public string? CarGear { get; init; }
        public int? CarLuggage { get; init; }
        public int? CarDoors { get; init; }
        public decimal CarPrice { get; init; }
        public int CarTypeId { get; init; }
        public int CarBrandId { get; set; }

        public List<IFormFile> CarImages { get; set; }
    }
}
