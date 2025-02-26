using System.Xml;
using CarApp.CarAppTest;
using CarApp.Core.Domain;
using CarApp.Core.Dto;
using CarApp.Core.ServiceInterface;
using CarApp.Data.Migrations;
using Xunit;

namespace CarApp.CarTest
{
    public class CarTest : TestBase
    {
        [Fact]
        public async Task CreateDataTest()
        {
            //Arrange
            CarDto dto = new();

            dto.CarName = "asd";
            dto.CarPrice = 12345 - 2f;
            dto.CarYear = DateTime.Now;
            dto.CreatedAt = DateTime.Now;
            dto.ModifiedAt = DateTime.Now;

            //Act
            var result = await Svc<ICarServices>().Create(dto);

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetDetails()
        {
            CarDto carDto = MockCarData();
            var car = await Svc<ICarServices>().Create(carDto);

            var result = await Svc<ICarServices>().DetailsAsync((Guid)car.CarId);

            Assert.NotNull(result);
        }

        [Fact]
        public async Task UpdateData()
        {

            var guidDb = Guid.Parse("2F39BA90-3C52-4DA9-69EA-08DD33187518");
            var guidNew = Guid.NewGuid();

            CarDto dto = MockCarData();

            Car domain = new();

            domain.CarId = guidNew;
            domain.CarName = "adsg";
            domain.CarPrice = 142;
            domain.CarYear = DateTime.Now;
            domain.CreatedAt = DateTime.UtcNow;
            domain.ModifiedAt = DateTime.UtcNow;

            await Svc<ICarServices>().Update(dto);

            Assert.Equal(domain.CarId, guidNew);
            Assert.DoesNotMatch(domain.CarName, dto.CarName);
            Assert.NotEqual(domain.CarPrice, dto.CarPrice);
            Assert.NotEqual(domain.CarYear, dto.CarYear);

        }

        [Fact]
        public async Task DeleteData()
        {
            CarDto realEstate = MockCarData();

            var Car1 = await Svc<ICarServices>().Create(realEstate);
            var Car2 = await Svc<ICarServices>().Create(realEstate);

            var result = await Svc<ICarServices>().Delete((Guid)Car1.CarId);

            Assert.NotEqual(result.CarId, Car2.CarId);
        }

        private CarDto MockCarData()
        {
            CarDto car = new()
            {
                CarName = "asd",
                CarPrice = 123 - 2f,
                CarYear = DateTime.Now,
                CreatedAt = DateTime.Now,
                ModifiedAt = DateTime.Now,
            };

            return car;
        }
    }
}