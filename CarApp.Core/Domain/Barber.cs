using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarApp.Core.Domain
{
    public class Barber
    {
        public Guid BarberId { get; set; }
        public string Name { get; set; }
        public string Experience { get; set; }
    }
}
