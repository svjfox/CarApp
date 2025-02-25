using CarApp.Core.Domain;
using CarApp.Core.Dto;

namespace CarApp.Core.ServiceInterface
{
    public interface ICarServices
    {
        Task<Car> DetailsAsync(Guid id);

        Task<Car> Create(CarDto dto);

        Task<Car> Update(CarDto dto);

        Task<Car> Delete(Guid id);
    }
}