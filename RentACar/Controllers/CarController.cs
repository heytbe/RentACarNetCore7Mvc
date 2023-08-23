using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RentACar.Context;
using RentACar.Extensions;
using RentACar.Models.Dto;
using RentACar.Models.Parameters;

namespace RentACar.Controllers
{
    public class CarController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public CarController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index(CarRequestParameters carRequestParameters)
        {
            var car = _context.Cars.Include(x => x.CarBrand).Include(x => x.CarType)
                .SearchBrand(carRequestParameters.SearchBrand)
                .FilterByPrice(carRequestParameters.MinPrice,carRequestParameters.MaxPrice,carRequestParameters.IsValidPrice)
                .FilterByBrand(carRequestParameters.carBrand)
                .FilterByModelDate(carRequestParameters.CarDate).ToList();
            var mapper = _mapper.Map<List<CarListDto>>(car);
            ViewBag.Brand = await CarBrand();
            return View(mapper);
        }

        private async Task<SelectList> CarBrand()
        {
            return new SelectList(await _context.Cars.Include(x => x.CarBrand).ToListAsync(), "Id", "CarBrand.CarBrands", 1);
        }
    }
}
