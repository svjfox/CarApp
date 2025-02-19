using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarApp.Core.Domain
{
    public class FileToDatabase
    {
        public Guid? Id { get; set; }  // Идентификатор изображения
        public string? ImageTitle { get; set; }  // Заголовок изображения
        public byte[] ImageData { get; set; }  // Данные изображения
        public Guid? CarId { get; set; }  // Идентификатор автомобиля, с которым связано изображение

        public Car Car { get; set; }  // Навигационное свойство для связи с автомобилем
    }

}
