using CarApp.Core.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarApp.Core.ServiceInterface
{
    public interface ICarService
    {
        Task<IEnumerable<CarDto>> GetAllCarsAsync();
        Task<CarDto> GetCarByIdAsync(int id);
        Task CreateCarAsync(CarDto carDto);
        Task UpdateCarAsync(int id, CarDto carDto);
        Task DeleteCarAsync(int id);
    }
}

