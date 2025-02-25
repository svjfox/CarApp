﻿namespace CarApp.Models.Cars
{
    public class CarIndexViewModel
    {
        public Guid? CarId { get; set; }

        public string? CarName { get; set; }

        public float? CarPrice { get; set; }

        public DateTime? CarYear { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime ModifiedAt { get; set; }

        public List<CarImageViewModel> Image { get; set; }
            = new List<CarImageViewModel>();

        public List<IFormFile> Files { get; set; }
    }
}