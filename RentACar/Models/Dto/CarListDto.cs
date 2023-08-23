namespace RentACar.Models.Dto
{
    public record CarListDto
    {
        public int Id { get; init; }
        public string Model { get; set; }
        public string CarImage { get; init; }
        public string CarDate { get; init; }
        public int CarPersons { get; init; }
        public string? CarGear { get; init; }
        public int? CarLuggage { get; init; }
        public int? CarDoors { get; init; }
        public decimal CarPrice { get; init; }
        public CarTypeDto CarType { get; init; }
        public CarBrandListDto CarBrand { get; set; }
    }
}
