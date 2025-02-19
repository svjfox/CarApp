using System;

namespace CarApp.Core.Domain
{
    public class Car
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string Color { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime ModifiedAt { get; set; } = DateTime.Now;
    }
}