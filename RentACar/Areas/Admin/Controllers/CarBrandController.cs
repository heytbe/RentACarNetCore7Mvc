using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentACar.Context;
using RentACar.Models;
using RentACar.Models.Dto;
using RentACar.Shared;

namespace RentACar.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CarBrandController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public CarBrandController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var brand = await _context.CarBrands.ToListAsync();
            var mapper = _mapper.Map<IEnumerable<CarBrandListDto>>(brand);
            return View(mapper);
        }

        public IActionResult BrandCreate()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> BrandCreate([FromForm] CarBrandCreateDto carBrandCreate)
        {
            CarBrand carBrand = new();
            carBrand.CarBrands = carBrandCreate.CarBrands;

            var image = await ImageUpload.Image(carBrandCreate.Image);
            carBrand.Image = image.ImagePath;

            await _context.AddAsync(carBrand);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete([FromRoute(Name ="id")] int id)
        {
            var carbrand = await _context.CarBrands.FindAsync(id);
            _context.Remove(carbrand);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
