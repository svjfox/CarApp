﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CarApp.Core.Domain;
using CarApp.Core.ServiceInterface;
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

        public async Task<IEnumerable<Car>> GetAllCarsAsync()
        {
            return await _context.Cars.ToListAsync();
        }

        public async Task<Car> GetCarByIdAsync(Guid id)
        {
            return await _context.Cars.FindAsync(id);
        }

        public async Task<Car> AddCarAsync(Car car)
        {
            _context.Cars.Add(car);
            await _context.SaveChangesAsync();
            return car;
        }

        public async Task<Car> UpdateCarAsync(Car car)
        {
            _context.Cars.Update(car);
            await _context.SaveChangesAsync();
            return car;
        }

        public async Task DeleteCarAsync(Guid id)
        {
            var car = await _context.Cars.FindAsync(id);
            if (car != null)
            {
                _context.Cars.Remove(car);
                await _context.SaveChangesAsync();
            }
        }
    }
}