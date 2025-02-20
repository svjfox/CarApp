using System;

namespace CarApp.Core.Domain
{
    public class Car
    {
        // Уникальный идентификатор автомобиля
        public Guid Id { get; set; } = Guid.NewGuid();

        // Бренд автомобиля
        public string Brand { get; set; }

        // Модель автомобиля
        public string Model { get; set; }

        // Год выпуска автомобиля
        public int Year { get; set; }

        // Цвет автомобиля
        public string Color { get; set; }

        // Дата создания записи
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // Дата последнего изменения записи
        public DateTime ModifiedAt { get; set; } = DateTime.Now;
    }
}
