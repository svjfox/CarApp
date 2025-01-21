using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarApp.Core.Dto;
using CarApp.Core.Domain;
using CarApp.Core.ServiceInterface;
using System.Runtime.ConstrainedExecution;
using CarApp.Data;
using Microsoft.EntityFrameworkCore;

namespace CarApp.ApplicationServices.Services
{
    public class CarService : ICarService
    {
        private readonly CarAppContext _context;

        public CarService(CarAppContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CarDto>> GetAllCarsAsync()
        {
            return await _context.Cars
                .Select(car => new CarDto
                {
                    Model = car.Model,
                    Manufacturer = car.Manufacturer,
                    Year = car.Year,
                    Color = car.Color
                })
                .ToListAsync();
        }

        public async Task<CarDto> GetCarByIdAsync(int id)
        {
            var car = await _context.Cars.FindAsync(id);
            if (car == null)
                return null;

            return new CarDto
            {
                Model = car.Model,
                Manufacturer = car.Manufacturer,
                Year = car.Year,
                Color = car.Color
            };
        }

        public async Task CreateCarAsync(CarDto carDto)
        {
            var car = new Car
            {
                Model = carDto.Model,
                Manufacturer = carDto.Manufacturer,
                Year = carDto.Year,
                Color = carDto.Color
            };
            _context.Cars.Add(car);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCarAsync(int id, CarDto carDto)
        {
            var car = await _context.Cars.FindAsync(id);
            if (car == null)
                return;

            car.Model = carDto.Model;
            car.Manufacturer = carDto.Manufacturer;
            car.Year = carDto.Year;
            car.Color = carDto.Color;
            car.ModifiedAt = DateTime.Now;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteCarAsync(int id)
        {
            var car = await _context.Cars.FindAsync(id);
            if (car == null)
                return;

            _context.Cars.Remove(car);
            await _context.SaveChangesAsync();
        }
    }
}
