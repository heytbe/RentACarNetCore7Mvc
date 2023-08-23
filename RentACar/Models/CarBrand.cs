namespace RentACar.Models
{
    public class CarBrand
    {
        public CarBrand()
        {
            Cars = new HashSet<Cars>();
        }
        public int Id { get; set; }
        public string CarBrands{ get; set; }
        public string Image { get; set; }
        public ICollection<Cars> Cars { get; set; }
    }
}
