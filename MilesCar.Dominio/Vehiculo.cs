using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilesCar.Dominio
{
    public class Vehiculo
    {
        public Guid id { get; set; }
        public string nombre { get; set; }
        public string tipo { get; set; }
        public decimal costo { get; set; }

    }
}
