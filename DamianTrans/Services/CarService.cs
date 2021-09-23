using AutoMapper;
using DamianTrans.Entities;
using DamianTrans.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DamianTrans.Services
{
    public interface ICarService
    {
        void createCar(CreateCarDto dto);
        Car deleteCar(int id);
        Car editCar(int id, CreateCarDto dto);
        CreateCarDto findCarForEdit(int id);
        Car findCarToDelete(int id);
        List<Car> getAllCars();
    }

    public class CarService : ICarService
    {
        private readonly DamianTransDbContext _dbContext;
        private readonly IMapper _mapper;

        public CarService(DamianTransDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public List<Car> getAllCars()
        {
            return _dbContext.Cars.ToList();
        }

        public void createCar(CreateCarDto dto)
        {
            var car = _mapper.Map<Car>(dto);
            _dbContext.Cars.Add(car);
            _dbContext.SaveChanges();
        }

        public CreateCarDto findCarForEdit(int id)
        {
            var car = _dbContext.Cars.FirstOrDefault(r => r.Id == id);

            if (car == null)
                return null;

            var carDto = _mapper.Map<CreateCarDto>(car);

            return carDto;
        }

        public Car editCar(int id, CreateCarDto dto)
        {
            var car = _dbContext.Cars.FirstOrDefault(r => r.Id == id);

            if (car == null)
                return null;

            car.CarBrand = dto.CarBrand;
            car.CarModel = dto.CarModel;
            car.CarInspectionDate = dto.CarInspectionDate;
            car.DateOfProduction = dto.DateOfProduction;
            car.LoadingCapacityInLiters = dto.LoadingCapacityInLiters;
            car.MileageInKm = dto.MileageInKm;

            _dbContext.SaveChanges();

            return car;
        }

        public Car findCarToDelete(int id)
        {
            var car = _dbContext.Cars.FirstOrDefault(r => r.Id == id);

            if (car == null)
                return null;

            return car;
        }

        public Car deleteCar(int id)
        {
            var car = _dbContext.Cars.FirstOrDefault(r => r.Id == id);
            if (car is null)
                return null;

            _dbContext.Remove(car);
            _dbContext.SaveChanges();

            return car;
        }
    }
}
