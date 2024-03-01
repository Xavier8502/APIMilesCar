using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilesCar.Dominio
{
    public class ConsultaRequest
    {
        public string localidadRecogida { get; set; }
        public string localidadDevolucion { get; set; }

    }

    public class ConsultaResponse
    {
        public List<Vehiculo> vehiculosDisponibles { get; set; }
    }
}
