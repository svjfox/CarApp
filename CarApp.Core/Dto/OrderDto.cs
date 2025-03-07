using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarApp.Core.Dto
{
    public class OrderDto
    {
        public Guid? OrderId { get; set; }
        public Guid ClientId { get; set; }
        public Guid BarberId { get; set; }
        public DateTime OrderDate { get; set; }
        public string Service { get; set; }
    }
}
