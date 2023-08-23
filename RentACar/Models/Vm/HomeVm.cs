using RentACar.Models.Dto;

namespace RentACar.Models.Vm
{
    public class HomeVm
    {
        public List<CarBrandListDto> CarBrandsList { get; set; }
        public List<CarListDto> CarListDtos { get; set; }
    }
}
