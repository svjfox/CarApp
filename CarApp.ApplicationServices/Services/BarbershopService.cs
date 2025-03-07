using CarApp.Core.Domain;
using CarApp.Core.Dto;
using CarApp.Core.ServiceInterface;
using CarApp.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarApp.ApplicationServices.Services
{
    public class BarbershopService : IBarbershopService
    {
        private readonly CarAppContext _context;

        public BarbershopService(CarAppContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<OrderDto>> GetOrdersAsync()
        {
            return await _context.Orders
                .Select(o => new OrderDto
                {
                    OrderId = o.OrderId,
                    ClientId = o.ClientId,
                    BarberId = o.BarberId,
                    OrderDate = o.OrderDate,
                    Service = o.Service
                }).ToListAsync();
        }

        public async Task<OrderDto> GetOrderByIdAsync(Guid id)
        {
            var order = await _context.Orders.FindAsync(id);
            return new OrderDto
            {
                OrderId = order.OrderId,
                ClientId = order.ClientId,
                BarberId = order.BarberId,
                OrderDate = order.OrderDate,
                Service = order.Service
            };
        }

        public async Task CreateOrUpdateOrderAsync(OrderDto dto)
        {
            var order = new Order
            {
                OrderId = dto.OrderId ?? Guid.NewGuid(),
                ClientId = dto.ClientId,
                BarberId = dto.BarberId,
                OrderDate = dto.OrderDate,
                Service = dto.Service
            };

            if (dto.OrderId == null)
            {
                _context.Orders.Add(order);
            }
            else
            {
                _context.Orders.Update(order);
            }

            await _context.SaveChangesAsync();
        }

        public async Task DeleteOrderAsync(Guid id)
        {
            var order = await _context.Orders.FindAsync(id);
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ClientDto>> GetClientsAsync()
        {
            return await _context.Clients
                .Select(c => new ClientDto
                {
                    ClientId = c.ClientId,
                    Name = c.Name,
                    Phone = c.Phone
                }).ToListAsync();
        }

        public async Task<IEnumerable<BarberDto>> GetBarbersAsync()
        {
            return await _context.Barbers
                .Select(b => new BarberDto
                {
                    BarberId = b.BarberId,
                    Name = b.Name,
                    Experience = b.Experience
                }).ToListAsync();
        }
    }
}
