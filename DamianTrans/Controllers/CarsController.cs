using AutoMapper;
using DamianTrans.Entities;
using DamianTrans.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DamianTrans.Controllers
{
    [Route("cars")]
    [ApiController]
    public class CarsController : Controller
    {
        private readonly DamianTransDbContext _dbContext;
        private readonly IMapper _mapper;

        public CarsController(DamianTransDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var cars = _dbContext.Cars.ToList();
            return View(cars);
        }

        [HttpGet("create")]
        public IActionResult Create()
        {
            return View(new CreateCarDto());
        }

        [HttpPost("create")]
        public IActionResult Create([FromForm] CreateCarDto dto)
        {
            var car = _mapper.Map<Car>(dto);
            _dbContext.Cars.Add(car);
            _dbContext.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var car = _dbContext.Cars.FirstOrDefault(r => r.Id == id);

            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }

        [HttpPost("{id}"), ActionName("Delete")]
        public IActionResult DeleteConfirmed ([FromRoute] int id)
        {
            var car = _dbContext.Cars.FirstOrDefault(r => r.Id == id);
            if (car is null)
                return View("Error");

            _dbContext.Remove(car);
            _dbContext.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
