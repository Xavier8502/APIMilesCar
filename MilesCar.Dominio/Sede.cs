using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilesCar.Dominio
{
    public class Sede
    {
        public Guid id { get; set; }
        public string nombre { get; set; }

        public Guid localidadId { get; set; }
        public Localidad? localidad { get; set; }

    }
}
