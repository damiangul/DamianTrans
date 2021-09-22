using DamianTrans.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DamianTrans
{
    public class ProjectSeeder
    {
        private readonly DamianTransDbContext _dbContext;
        public ProjectSeeder(DamianTransDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Seed()
        {
            if(_dbContext.Database.CanConnect())
            {
                if(!_dbContext.Roles.Any())
                {
                    var roles = GetRoles();
                    _dbContext.Roles.AddRange(roles);
                    _dbContext.SaveChanges();
                }

                if(!_dbContext.Cars.Any())
                {
                    var cars = GetCars();
                    _dbContext.Cars.AddRange(cars);
                    _dbContext.SaveChanges();
                }

                if(!_dbContext.Statuses.Any())
                {
                    var statuses = GetStatuses();
                    _dbContext.Statuses.AddRange(statuses);
                    _dbContext.SaveChanges();
                }
            }
        }

        private IEnumerable<Role> GetRoles()
        {
            var roles = new List<Role>()
            {
                new Role()
                {
                    Name = "User"
                },
                new Role()
                {
                    Name = "Worker"
                },
                new Role()
                {
                    Name = "Admin"
                }
            };

            return roles;
        }
        private IEnumerable<Car> GetCars()
        {
            var cars = new List<Car>()
            {
                new Car()
                {
                    CarBrand = "Volkswagen",
                    CarModel = "Transporter",
                    DateOfProduction = new DateTime(2016, 8, 13),
                    LoadingCapacityInLiters = "500",
                    MileageInKm = 88000,
                    CarInspectionDate = new DateTime(2021, 4, 20)
                },
                new Car()
                {
                    CarBrand = "Ford",
                    CarModel = "Transit",
                    DateOfProduction = new DateTime(2021, 5, 1),
                    LoadingCapacityInLiters = "300",
                    MileageInKm = 1,
                    CarInspectionDate = new DateTime(2021, 5, 1)
                },
            };

            return cars;
        }
        private IEnumerable<Status> GetStatuses()
        {
            var statuses = new List<Status>()
            {
                new Status()
                {
                    Name = "Order acceptance.",
                    Description = "Order has been accepted by the employee."
                },
                new Status()
                {
                    Name = "Order unpaid.",
                    Description = "Customer has not paid yet."
                },
                new Status()
                {
                    Name = "The order has been paid for.",
                    Description = "The company has accepted the money."
                },
                new Status()
                {
                    Name = "The driver is going to get the parcel.",
                    Description = "The driver has already left the company to get the order."
                },
                new Status()
                {
                    Name = "Packing the goods.",
                    Description = "Safe preparation of the goods on the route."
                },
                new Status()
                {
                    Name = "Arrival at destination.",
                    Description = "The package has been delivered by the driver."
                },
                new Status()
                {
                    Name = "Arrival at destination.",
                    Description = "The parcel has been damaged by the driver."
                },
            };

            return statuses;
        }
    }
}
