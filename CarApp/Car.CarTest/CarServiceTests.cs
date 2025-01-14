// Car.CarTest/CarServiceTests.cs
using CarApp.ApplicationServices;
using CarApp.ApplicationServices.Interfaces;
using CarApp.Core.Entities;
using CarApp.Data;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Xunit;

namespace CarApp.CarTest
{
    public class CarServiceTests
    {
        private readonly ApplicationDbContext _context;
        private readonly ICarService _carService;

        public CarServiceTests()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "CarAppTestDb")
                .Options;
            _context = new ApplicationDbContext(options);
            _carService = new CarService(_context);
        }

        [Fact]
        public void AddCar_ShouldAddCarToDatabase()
        {
            var car = new Car { Make = "Toyota", Model = "Corolla", Year = 2020, Color = "Red" };
            _carService.AddCar(car);

            var result = _carService.GetCarById(car.Id);
            Assert.NotNull(result);
            Assert.Equal("Toyota", result.Make);
        }

        [Fact]
        public void UpdateCar_ShouldUpdateCarDetails()
        {
            var car = new Car { Make = "Toyota", Model = "Corolla", Year = 2020, Color = "Red" };
            _carService.AddCar(car);
            car.Color = "Blue";
            _carService.UpdateCar(car);

            var result = _carService.GetCarById(car.Id);
            Assert.Equal("Blue", result.Color);
        }

        [Fact]
        public void DeleteCar_ShouldRemoveCarFromDatabase()
        {
            var car = new Car { Make = "Toyota", Model = "Corolla", Year = 2020, Color = "Red" };
            _carService.AddCar(car);
            _carService.DeleteCar(car.Id);

            var result = _carService.GetCarById(car.Id);
            Assert.Null(result);
        }

        [Fact]
        public void GetAllCars_ShouldReturnAllCars()
        {
            var car1 = new Car { Make = "Toyota", Model = "Corolla", Year = 2020, Color = "Red" };
            var car2 = new Car { Make = "Honda", Model = "Civic", Year = 2021, Color = "Blue" };
            _carService.AddCar(car1);
            _carService.AddCar(car2);

            var result = _carService.GetAllCars();
            Assert.Equal(2, result.Count());
        }
    }
}
