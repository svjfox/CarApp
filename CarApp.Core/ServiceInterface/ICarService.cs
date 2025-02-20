using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CarApp.Core.Domain;

namespace CarApp.Core.ServiceInterface
{
    public interface ICarService
    {
        Task<IEnumerable<Car>> GetAllCarsAsync();  // Получение всех автомобилей
        Task<Car> GetCarByIdAsync(Guid id);  // Получение автомобиля по ID
        Task<Car> AddCarAsync(Car car);  // Добавление нового автомобиля
        Task<Car> UpdateCarAsync(Car car);  // Обновление автомобиля
        Task DeleteCarAsync(Guid id);  // Удаление автомобиля
    }
}
