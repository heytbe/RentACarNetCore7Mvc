using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RentACar.Context;
using RentACar.Models;
using RentACar.Models.Dto;
using RentACar.Shared;

namespace RentACar.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CarController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public CarController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var car = await _context.Cars.Include(x => x.CarBrand).Include(x => x.CarType).ToListAsync();
            var mapper = _mapper.Map<IEnumerable<CarListDto>>(car);
            return View(mapper);
        }

        public async Task<IActionResult> CarCreate()
        {
            ViewBag.Brand = await CarBrand();
            ViewBag.CarType = await CarType();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CarCreate([FromForm] CarCreateDto createDto)
        {
            Cars cars = new();
            cars.Model = createDto.Model;
            cars.CarDate = createDto.CarDate;
            cars.CarPersons = createDto.CarPersons;
            cars.CarGear = createDto.CarGear;
            cars.CarLuggage = createDto.CarLuggage;
            cars.CarDoors = createDto.CarDoors;
            cars.CarPrice = createDto.CarPrice;

            cars.CarBrandId = createDto.CarBrandId;
            cars.CarTypeId = createDto.CarTypeId;

            var image = await ImageUpload.Image(createDto.CarImage);
            cars.CarImage = image.ImagePath;

            foreach (var item in createDto.CarImages)
            {
                var images = await ImageUpload.Image(item);

                cars.CarImages.Add(new CarImages()
                {
                    ImageName = images.ImagePath,
                    ImageType = images.ImageName
                });

            }

            await _context.AddAsync(cars);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete([FromRoute(Name ="id")] int id)
        {
            var car = await _context.Cars.FindAsync(id);
           _context?.Remove(car);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }


        private async Task<SelectList> CarBrand()
        {
            return new SelectList(await _context.CarBrands.ToListAsync(), "Id", "CarBrands", 1);
        }

        private async Task<SelectList> CarType()
        {
            return new SelectList(await _context.CarTypes.ToListAsync(), "Id", "CarTypes", 1);
        }
    }
}
