namespace RentACar.Models
{
    public class Cars
    {
        public Cars()
        {
            CarImages = new HashSet<CarImages>();
        }
        public int Id { get; set; }
        public string? Model { get; set; }
        public string CarImage { get; set; }
        public string CarDate { get; set; }
        public int CarPersons { get; set; }
        public string? CarGear { get; set; }
        public int? CarLuggage { get; set; }
        public int? CarDoors { get; set; }
        public decimal CarPrice { get; set; }
        public int CarTypeId { get; set; }
        public CarType CarType { get; set; }
        public int CarBrandId { get; set; }
        public CarBrand CarBrand { get; set; }

        public ICollection<CarImages> CarImages { get; set; }
    }
}
