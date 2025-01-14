using System.Collections.Generic;
using CarApp.Core.Entities;


namespace CarApp.ApplicationServices.Interfaces
{
    public interface ICarService
    {
        IEnumerable<Car> GetAllCars();
        Car GetCarById(int id);
        void AddCar(Car car);
        void UpdateCar(Car car);
        void DeleteCar(int id);
    }
}
