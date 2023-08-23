namespace RentACar.Models
{
    public class CarImages
    {
        public int Id { get; set; }
        public string? ImageName { get; set; }
        public string? ImageType { get; set; }
        public int CarsId { get; set; }
        public Cars Cars { get; set; }
    }
}
