﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarApp.Data;
using CarApp.Core.ServiceInterface;
using CarApp.Core.Domain;
using CarApp.Core.Dto;
using CarApp.Models.Cars;
using static System.Net.Mime.MediaTypeNames;



namespace CarApp.Controllers
{
    public class CarsController : Controller
    {
        private readonly CarAppContext _context;
        private readonly ICarServices _carServices;
        private readonly IFileToDatabaseServices _fileToDatabaseServices;

        public CarsController
            (
                CarAppContext context,
                ICarServices CarServices,
                IFileToDatabaseServices FileToDatabaseServices
            )
        {
            _context = context;
            _carServices = CarServices;
            _fileToDatabaseServices = FileToDatabaseServices;
        }

        public IActionResult Index()
        {
            var result = _context.Cars
                .Select(x => new CarIndexViewModel
                {
                    CarId = x.CarId,
                    CarName = x.CarName,
                    CarPrice = x.CarPrice,
                    CarYear = x.CarYear,

                });

            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var car = await _carServices.DetailsAsync(id);

            if (car == null)
            {
                return NotFound();
            }

            var images = await _context.FileToDatabase
                .Where(x => x.CarId == id)
                .Select(y => new CarImageViewModel
                {
                    CarId = y.Id,
                    ImageId = y.Id,
                    ImageData = y.ImageData,
                    ImageTitle = y.ImageTitle,
                    Image = string.Format("data:image/gif;base64,{0}", Convert.ToBase64String(y.ImageData))
                }).ToArrayAsync();

            var vm = new CarDetailsViewModel();

            vm.CarId = car.CarId;
            vm.CarName = car.CarName;
            vm.CarYear = car.CarYear;
            vm.CarPrice = car.CarPrice;
            vm.CreatedAt = car.CreatedAt;
            vm.ModifiedAt = car.ModifiedAt;
            vm.Image.AddRange(images);

            return View(vm);
        }

        [HttpGet]
        public IActionResult Create()
        {
            CarCreateAndUpdateViewModel car = new();

            return View("CreateAndUpdate", car);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CarCreateAndUpdateViewModel vm)
        {
            var dto = new CarDto()
            {
                CarId = vm.CarId,
                CarName = vm.CarName,
                CarPrice = vm.CarPrice,
                CarYear = vm.CarYear,
                Files = vm.Files,
                Image = vm.Image
                    .Select(x => new FileToDatabaseDto
                    {
                        Id = x.ImageId,
                        ImageData = x.ImageData,
                        ImageTitle = x.ImageTitle,
                        CarId = x.CarId
                    }).ToArray()
            };

            var result = await _carServices.Create(dto);

            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index), vm);
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var car = await _carServices.DetailsAsync(id);

            if (car == null)
            {
                return NotFound();
            }

            var images = await _context.FileToDatabase
                .Where(x => x.CarId == id)
                .Select(y => new CarImageViewModel
                {
                    CarId = y.CarId,
                    ImageId = y.Id,
                    ImageData = y.ImageData,
                    ImageTitle = y.ImageTitle,
                    Image = string.Format("data:image/gif;base64,{0}", Convert.ToBase64String(y.ImageData))
                }).ToArrayAsync();

            var vm = new CarCreateAndUpdateViewModel();

            vm.CarId = car.CarId;
            vm.CarName = car.CarName;
            vm.CarPrice = car.CarPrice;
            vm.CarYear = car.CarYear;
            vm.Image.AddRange(images);

            return View("CreateAndUpdate", vm);
        }

        [HttpPost]
        public async Task<IActionResult> Update(CarCreateAndUpdateViewModel vm)
        {
            var dto = new CarDto()
            {

                CarId = vm.CarId,
                CarName = vm.CarName,
                CarPrice = vm.CarPrice,
                CarYear = vm.CarYear,
                CreatedAt = vm.CreatedAt,
                ModifiedAt = vm.ModifiedAt,
                Files = vm.Files,
                Image = vm.Image
                    .Select(x => new FileToDatabaseDto
                    {
                        Id = x.ImageId,
                        ImageData = x.ImageData,
                        ImageTitle = x.ImageTitle,
                        CarId = x.CarId
                    }).ToArray()
            };


            var result = await _carServices.Update(dto);

            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var car = await _carServices.DetailsAsync(id);

            if (car == null)
            {
                return NotFound();
            }

            var images = await _context.FileToDatabase
                .Where(x => x.CarId == id)
                .Select(y => new CarImageViewModel
                {
                    CarId = y.CarId,
                    ImageId = y.Id,
                    ImageData = y.ImageData,
                    ImageTitle = y.ImageTitle,
                    Image = string.Format("data:image/gif;base64,{0}", Convert.ToBase64String(y.ImageData))
                }).ToArrayAsync();

            var vm = new CarDeleteViewModel();

            vm.CarId = car.CarId;
            vm.CarName = car.CarName;
            vm.CarPrice = car.CarPrice;
            vm.CarYear = car.CarYear;
            vm.CreatedAt = car.CreatedAt;
            vm.ModifiedAt = car.ModifiedAt;
            vm.Image.AddRange(images);

            return View(vm);
        }

        [HttpPost]
        // Why setting Id variable name show's null value but changing it to CarId then it's works? How does that work?
        public async Task<IActionResult> DeleteConfirmation(Guid CarId)
        {

            var car = await _carServices.Delete(CarId);

            if (car == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> RemoveImage(CarImageViewModel file)
        {
            var dto = new FileToDatabaseDto()
            {
                Id = file.ImageId
            };

            var image = await _fileToDatabaseServices.RemoveImageFromDatabase(dto);

            if (image == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }
    }
}