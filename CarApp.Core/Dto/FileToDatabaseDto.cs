﻿namespace CarApp.Core.Dto
{
    public class FileToDatabaseDto
    {
        public Guid? Id { get; set; }
        public string? ImageTitle { get; set; }
        public byte[] ImageData { get; set; }
        public Guid? CarId { get; set; }
    }
}