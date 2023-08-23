namespace RentACar.Models.Parameters
{
    public class CarRequestParameters : RequestParameters
    {
        public string? SearchBrand { get; set; }
        public int MinPrice { get; set; }
        public int MaxPrice { get; set; } = int.MaxValue;
        public int? carBrand { get; set; }
        public string? CarDate { get; set; }
        public bool IsValidPrice => MaxPrice > MinPrice;
    }
}
