using CarApp.Core.Dto;
using CarApp.Core.ServiceInterface;
using CarApp.Models.Barbershop;
using Microsoft.AspNetCore.Mvc;

namespace CarApp.Controllers
{
    public class BarbershopController : Controller
    {
        private readonly IBarbershopService _barbershopService;

        public BarbershopController(IBarbershopService barbershopService)
        {
            _barbershopService = barbershopService;
        }

        public async Task<IActionResult> Index()
        {
            var orders = await _barbershopService.GetOrdersAsync();
            var orderViewModels = orders.Select(o => new OrderViewModel
            {
                OrderId = o.OrderId ?? Guid.Empty, // Явное приведение типа
                ClientId = o.ClientId,
                BarberId = o.BarberId,
                OrderDate = o.OrderDate,
                Service = o.Service
            }).ToList();

            return View(orderViewModels);
        }

        public async Task<IActionResult> Clients()
        {
            var clients = await _barbershopService.GetClientsAsync();
            var clientViewModels = clients.Select(c => new ClientViewModel
            {
                ClientId = c.ClientId,
                Name = c.Name,
                Phone = c.Phone
            }).ToList();

            return View(clientViewModels);
        }

        public async Task<IActionResult> Barbers()
        {
            var barbers = await _barbershopService.GetBarbersAsync();
            var barberViewModels = barbers.Select(b => new BarberViewModel
            {
                BarberId = b.BarberId,
                Name = b.Name,
                Experience = b.Experience
            }).ToList();

            return View(barberViewModels);
        }
    }
}
