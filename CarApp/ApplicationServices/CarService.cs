using CarApp.Core.Entities;
using CarApp.ApplicationServices.Interfaces;
using CarApp.Data;

namespace CarApp.ApplicationServices
{
    public class CarService : ICarService
    {
        private readonly ApplicationDbContext _context;

        public CarService(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Car> GetAllCars() => _context.Cars;

        public Car GetCarById(int id) => _context.Cars.Find(id);

        public void AddCar(Car car)
        {
            car.CreatedAt = DateTime.Now;
            car.ModifiedAt = DateTime.Now;
            _context.Cars.Add(car);
            _context.SaveChanges();
        }

        public void UpdateCar(Car car)
        {
            car.ModifiedAt = DateTime.Now;
            _context.Cars.Update(car);
            _context.SaveChanges();
        }

        public void DeleteCar(int id)
        {
            var car = _context.Cars.Find(id);
            if (car != null)
            {
                _context.Cars.Remove(car);
                _context.SaveChanges();
            }
        }
    }
}