using Microsoft.AspNetCore.Mvc;

namespace CarApp.Controllers
{
    public class HomeController : Controller
    {
        // Действие для отображения главной страницы
        public IActionResult Index()
        {
            return View();
        }

        // Действие для отображения страницы "О нас"
        public IActionResult About()
        {
            return View();
        }

        // Действие для отображения страницы "Контакты"
        public IActionResult Contact()
        {
            return View();
        }

        // Действие для отображения страницы "Политика конфиденциальности"
        public IActionResult Privacy()
        {
            return View();
        }
    }
}