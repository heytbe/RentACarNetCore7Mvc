using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentACar.Context;
using RentACar.Models;
using RentACar.Models.Dto;
using RentACar.Models.Vm;
using System.Diagnostics;

namespace RentACar.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public HomeController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            HomeVm homeVm = new HomeVm();
            homeVm.CarBrandsList = await CarBrand();
            homeVm.CarListDtos = await Car();
            return View(homeVm);
        }

        private async Task<List<CarBrandListDto>> CarBrand()
        {
            var carbrand = await _context.CarBrands.ToListAsync();
            var mapper = _mapper.Map<List<CarBrandListDto>>(carbrand);
            return mapper;
        }

        private async Task<List<CarListDto>> Car()
        {
            var car = await _context.Cars.Include(x => x.CarBrand).Include(x => x.CarType).ToListAsync();
            var mapper = _mapper.Map<List<CarListDto>>(car);
            return mapper;
        }
    }
}