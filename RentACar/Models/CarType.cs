namespace RentACar.Models
{
    public class CarType
    {
        public CarType()
        {
            Cars = new HashSet<Cars>();
        }
        public int Id { get; set; }
        public string CarTypes { get; set; }

        public ICollection<Cars> Cars { get; set; }
    }
}
