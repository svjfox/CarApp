using CarApp.Core.Domain;
using CarApp.Core.Dto;

namespace CarApp.Core.ServiceInterface
{
    public interface IFileToDatabaseServices
    {
        void UploadFilesToDatabase(CarDto dto, Car domain);

        Task<FileToDatabase> RemoveImageFromDatabase(FileToDatabaseDto dto);

        Task SomeMethod();
    }


}

