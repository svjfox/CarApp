using System;

namespace CarApp.Core.Dto
{
    public class CarDto
    {
        // Идентификатор автомобиля
        public int Id { get; set; }

        // Модель автомобиля
        public string Model { get; set; }

        // Производитель автомобиля
        public string Manufacturer { get; set; }

        // Год выпуска
        public int Year { get; set; }

        // Цвет автомобиля
        public string Color { get; set; }

        // Дата создания записи
        public DateTime CreatedAt { get; set; }

        // Дата последнего изменения записи
        public DateTime ModifiedAt { get; set; }
    }
}
