using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilesCar.Dominio
{
    public class VehiculosXSede
    {
        public Guid vehiculoId { get; set; }
        public Guid sedeId { get; set; }
        public int cantidadEnStock { get; set; }

        public Vehiculo? vehiculo { get; set; }
        public Sede? sede { get; set; }
    }
}
