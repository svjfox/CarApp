
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using CarApp.Core.Domain;
using CarApp.Core.Dto;
using CarApp.Core.ServiceInterface;
using CarApp.Data;

namespace CarApp.ApplicationService.Services
{
    public class FileToDatabaseService : IFileToDatabaseServices
    {

        private readonly IHostEnvironment _webHost;
        private readonly CarAppContext _context;


        public FileToDatabaseService(IHostEnvironment webHost, CarAppContext context)
        {
            _webHost = webHost;
            _context = context;
        }

        public void UploadFilesToDatabase(CarDto dto, Car domain)
        {
            if (dto.Files != null && dto.Files.Count > 0)
            {
                foreach (var image in dto.Files)
                {
                    using (var target = new MemoryStream())
                    {
                        FileToDatabase files = new FileToDatabase()
                        {
                            Id = Guid.NewGuid(),
                            ImageTitle = image.FileName,
                            CarId = domain.CarId
                        };

                        image.CopyTo(target);
                        files.ImageData = target.ToArray();

                        _context.FileToDatabase.Add(files);
                    }
                }
            }
        }

        public async Task<FileToDatabase> RemoveImageFromDatabase(FileToDatabaseDto dto)
        {
            var image = await _context.FileToDatabase
                .Where(x => x.Id == dto.Id)
                .FirstOrDefaultAsync();

            _context.FileToDatabase.Remove(image);
            await _context.SaveChangesAsync();

            return image;
        }

        public Task SomeMethod()
        {
            // Ваш код
            return Task.CompletedTask;
        }

    }
}