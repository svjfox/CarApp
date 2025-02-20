//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Design;
//using Microsoft.Extensions.Configuration;
//using System.IO;


//namespace CarApp.Data
//{
//    public class CarAppContextFactory : IDesignTimeDbContextFactory<CarAppContext>
//    {
//        public CarAppContext CreateDbContext(string[] args)
//        {
//            // Настройка конфигурации для чтения строки подключения из appsettings.json
//            IConfigurationRoot configuration = new ConfigurationBuilder()
//                .SetBasePath(Directory.GetCurrentDirectory()) // Указываем текущую директорию
//                .AddJsonFile("appsettings.json") // Указываем файл конфигурации
//                .Build();

//            // Создание DbContextOptions
//            var optionsBuilder = new DbContextOptionsBuilder<CarAppContext>();
//            var connectionString = configuration.GetConnectionString("DefaultConnection");
//            optionsBuilder.UseSqlServer(connectionString, b => b.MigrationsAssembly("CarApp.Data"));

//            return new CarAppContext(optionsBuilder.Options);
//        }
//    }
//}