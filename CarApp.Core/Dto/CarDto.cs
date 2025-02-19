using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarApp.Core.Dto
{
    public class CarDto
    {
        public int Id { get; set; }  // Идентификатор автомобиля
        public string Model { get; set; }  // Модель автомобиля
        public string Manufacturer { get; set; }  // Производитель
        public int Year { get; set; }  // Год выпуска
        public string Color { get; set; }  // Цвет автомобиля
        public DateTime CreatedAt { get; set; }  // Дата создания
        public DateTime ModifiedAt { get; set; }  // Дата последнего изменения
    }

}

