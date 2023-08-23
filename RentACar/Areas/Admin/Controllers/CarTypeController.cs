using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentACar.Context;
using RentACar.Models;
using RentACar.Models.Dto;

namespace RentACar.Areas.Controllers
{
    [Area("Admin")]
    public class CarTypeController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public CarTypeController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var cartype = await _context.CarTypes.ToListAsync();
            var mapper = _mapper.Map<IEnumerable<CarTypeDto>>(cartype);

            return View(mapper);
        }

        public IActionResult TypeCreate()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> TypeCreate([FromForm] CarTypeDto typeDto)
        {
            CarType carType = new();

            carType.CarTypes = typeDto.CarTypes;

           await _context.AddAsync(carType);
           await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}
