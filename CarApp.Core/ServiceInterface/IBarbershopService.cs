using CarApp.Core.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarApp.Core.ServiceInterface
{
    public interface IBarbershopService
    {
        Task<IEnumerable<OrderDto>> GetOrdersAsync();
        Task<OrderDto> GetOrderByIdAsync(Guid id);
        Task CreateOrUpdateOrderAsync(OrderDto dto);
        Task DeleteOrderAsync(Guid id);
        Task<IEnumerable<ClientDto>> GetClientsAsync();
        Task<IEnumerable<BarberDto>> GetBarbersAsync();
    }
}
