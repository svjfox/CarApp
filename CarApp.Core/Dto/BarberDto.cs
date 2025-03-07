using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarApp.Core.Dto
{
    public class BarberDto
    {
        public Guid BarberId { get; set; }
        public string Name { get; set; }
        public string Experience { get; set; }
    }
}
