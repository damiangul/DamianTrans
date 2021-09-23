using AutoMapper;
using DamianTrans.Entities;
using DamianTrans.Models;
using DamianTrans.Services;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DamianTrans.Controllers
{
    [Route("cars")]
    [ApiController]
    public class CarsController : Controller
    {
        private readonly ICarService _service;

        public CarsController(ICarService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var cars = _service.getAllCars();
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
            _service.createCar(dto);

            return RedirectToAction("Index");
        }

        [HttpGet("edit/{id}")]
        public IActionResult Edit([FromRoute] int id)
        {
            var carDto = _service.findCarForEdit(id);

            if (carDto == null)
            {
                return NotFound();
            }    

            return View(carDto);
        }

        [HttpPost("edit/{id}")]
        public IActionResult Edit([FromRoute] int id, [FromForm] CreateCarDto dto)
        {
            var car = _service.editCar(id, dto);

            if (car == null)
                return NotFound();

            return RedirectToAction("Index");
        }

        [HttpGet("delete/{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var car = _service.findCarToDelete(id);

            if (car == null)
                return NotFound();

            return View(car);
        }

        [HttpPost("delete/{id}"), ActionName("delete")]
        public IActionResult DeleteConfirmed ([FromRoute] int id)
        {
            var car = _service.deleteCar(id);

            if (car is null)
                return NotFound();

            return RedirectToAction("Index");
        }
    }
}
