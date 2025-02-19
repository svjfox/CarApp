using System.Collections.Generic;
using System.Threading.Tasks;
using CarApp.Core.Domain;

namespace CarApp.Core.ServiceInterface
{
    public interface ICarService
    {
        Task<IEnumerable<Car>> GetAllCarsAsync();
        Task<Car> GetCarByIdAsync(Guid id);
        Task<Car> AddCarAsync(Car car);
        Task<Car> UpdateCarAsync(Car car);
        Task DeleteCarAsync(Guid id);
    }
}