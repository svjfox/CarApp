using System;
using System.Threading.Tasks;
using CarApp.Core.Domain;
using CarApp.Core.ServiceInterface;
using Microsoft.AspNetCore.Mvc;

namespace CarApp.Controllers
{
    public class CarsController : Controller
    {
        private readonly ICarService _carService;

        public CarsController(ICarService carService)
        {
            _carService = carService;
        }

        // Получение всех автомобилей
        public async Task<IActionResult> Index()
        {
            var cars = await _carService.GetAllCarsAsync();
            return View(cars);
        }

        // Страница для создания нового автомобиля
        public IActionResult Create()
        {
            return View();
        }

        // Обработка формы создания нового автомобиля
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Car car)
        {
            if (ModelState.IsValid)
            {
                await _carService.AddCarAsync(car);
                return RedirectToAction(nameof(Index));
            }
            return View(car);
        }

        // Страница для редактирования автомобиля
        public async Task<IActionResult> Edit(Guid id)
        {
            var car = await _carService.GetCarByIdAsync(id);
            if (car == null)
            {
                return NotFound();
            }
            return View(car);
        }

        // Обработка формы редактирования автомобиля
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, Car car)
        {
            if (id != car.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                await _carService.UpdateCarAsync(car);
                return RedirectToAction(nameof(Index));
            }
            return View(car);
        }

        // Страница для удаления автомобиля
        public async Task<IActionResult> Delete(Guid id)
        {
            var car = await _carService.GetCarByIdAsync(id);
            if (car == null)
            {
                return NotFound();
            }
            return View(car);
        }

        // Обработка формы удаления автомобиля
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _carService.DeleteCarAsync(id);
            return RedirectToAction(nameof(Index));
        }

        // Страница для просмотра деталей автомобиля
        public async Task<IActionResult> Details(Guid id)
        {
            var car = await _carService.GetCarByIdAsync(id);
            if (car == null)
            {
                return NotFound();
            }
            return View(car);
        }
    }
}
