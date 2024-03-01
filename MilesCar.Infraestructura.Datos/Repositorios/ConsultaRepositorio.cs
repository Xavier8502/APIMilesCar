using MilesCar.Dominio;
using MilesCar.Dominio.Interfaces.Repositorio;
using MilesCar.Infraestructura.Datos.Contextos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilesCar.Infraestructura.Datos.Repositorios
{
    public class ConsultaRepositorio : IConsultaRepositorio<ConsultaRequest, ConsultaResponse>
    {
        private MyDbContext _db;

        public ConsultaRepositorio(MyDbContext context)
        {
            _db = context;
        }
        public ConsultaResponse ConsultaVehiculosDis(ConsultaRequest tentidadreq)
        {
            var consulta = new ConsultaResponse();

            var localidadRecogida = _db.Localidades.Where(p => p.nombre == tentidadreq.localidadRecogida).FirstOrDefault();
            var localidadDevolucion = _db.Localidades.Where(p => p.nombre == tentidadreq.localidadDevolucion).FirstOrDefault();

            var sedes = _db.Sedes.Where(p => p.localidadId == localidadRecogida.id).ToList();

            var vehxsede = _db.VehiculosXSedes.ToList();

            var vehiculos = _db.Vehiculos.ToList();

            var res = (from sede in sedes
                       join vehxs in vehxsede on sede.id equals vehxs.sedeId
                       join veh in vehiculos on vehxs.vehiculoId equals veh.id
                       select new Vehiculo()
                       {
                           id = veh.id,
                           nombre = veh.nombre,
                           costo = veh.costo,
                           tipo = veh.tipo
                       }
                      ).ToList();
            consulta.vehiculosDisponibles = res;

            return consulta;
        }
    }
}
