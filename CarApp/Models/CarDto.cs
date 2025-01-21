namespace CarApp.Models
{
    public class CarDto
    {
        public string Model { get; set; }  // Модель машины
        public string Manufacturer { get; set; }  // Производитель
        public int Year { get; set; }  // Год выпуска
        public string Color { get; set; }  // Цвет машины
        public DateTime CreatedAt { get; set; }  // Дата создания
        public DateTime ModifiedAt { get; set; }  // Дата последнего изменения
    }
}
