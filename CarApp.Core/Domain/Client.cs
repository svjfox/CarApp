using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarApp.Core.Domain
{
    public class Client
    {
        public Guid ClientId { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
    }
}
