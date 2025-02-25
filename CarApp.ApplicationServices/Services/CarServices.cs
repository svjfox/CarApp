﻿using Microsoft.EntityFrameworkCore;

using CarApp.Data;
using CarApp.Core.ServiceInterface;
using CarApp.Core.Domain;
using CarApp.Core.Dto;
using System.Xml;


namespace CarApp.ApplicationService.Services
{
    public class CarServices : ICarServices
    {
        private readonly CarAppContext _context;
        private readonly IFileToDatabaseServices _fileToDatabaseServices;

        public CarServices
            (
                CarAppContext context,
                IFileToDatabaseServices fileToDatabaseServices
            )
        {
            _context = context;
            _fileToDatabaseServices = fileToDatabaseServices;
        }

        public async Task<Car> DetailsAsync(Guid id)
        {
            var result = await _context.Cars
                .FirstOrDefaultAsync(x => x.CarId == id);

            return result;
        }

        public async Task<Car> Create(CarDto dto)
        {
            Car car = new();

            car.CarId = Guid.NewGuid();
            car.CarName = dto.CarName;
            car.CarPrice = dto.CarPrice;
            car.CarYear = dto.CarYear;
            car.CreatedAt = DateTime.Now;
            car.ModifiedAt = DateTime.Now;

            if (dto.Files != null)
            {
                _fileToDatabaseServices.UploadFilesToDatabase(dto, car);
            }


            await _context.Cars.AddAsync(car);
            await _context.SaveChangesAsync();

            return car;
        }

        public async Task<Car> Update(CarDto dto)
        {
            Car domain = new();

            domain.CarId = dto.CarId;
            domain.CarName = dto.CarName;
            domain.CarPrice = dto.CarPrice;
            domain.CarYear = dto.CarYear;
            domain.CreatedAt = dto.CreatedAt;
            domain.ModifiedAt = DateTime.Now;

            if (dto.Files != null)
            {
                _fileToDatabaseServices.UploadFilesToDatabase(dto, domain);
            }

            _context.Cars.Update(domain);
            await _context.SaveChangesAsync();

            return domain;
        }

        public async Task<Car> Delete(Guid id)
        {
            var car = await _context.Cars
                .FirstOrDefaultAsync(x => x.CarId == id);

            _context.Cars.Remove(car);
            await _context.SaveChangesAsync();

            return car;
        }
    }
}