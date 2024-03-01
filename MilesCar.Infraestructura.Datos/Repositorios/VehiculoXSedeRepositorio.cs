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
    public class VehiculoXSedeRepositorio : IRepositorioVehiculoPorSede<VehiculosXSede, Guid>
    {
        private MyDbContext _db;

        public VehiculoXSedeRepositorio(MyDbContext dbContext)
        {
            _db = dbContext;
        }

        public VehiculosXSede Agregar(VehiculosXSede entidad)
        {
            _db.VehiculosXSedes.Add(entidad);
            return entidad;
        }

        public void GuardarTodosLosCambios()
        {
            _db.SaveChanges();
        }

        public List<VehiculosXSede> Listar()
        {
            var vehxSede = _db.VehiculosXSedes.ToList();
            vehxSede.ForEach(veh => {
                veh.sede = _db.Sedes.Where(p=> p.id == veh.sedeId).FirstOrDefault();
                veh.vehiculo = _db.Vehiculos.Where(p => p.id == veh.vehiculoId).FirstOrDefault();
            });
            return vehxSede;
        }

        public VehiculosXSede SeleccionarPorID(Guid entidadId)
        {
            var itemSeleccionado = _db.VehiculosXSedes.Where(p=> p.vehiculoId == entidadId).FirstOrDefault();
            itemSeleccionado.sede = _db.Sedes.Where(p => p.id == itemSeleccionado.sedeId).FirstOrDefault();
            itemSeleccionado.vehiculo = _db.Vehiculos.Where(p => p.id == itemSeleccionado.vehiculoId).FirstOrDefault();
            return itemSeleccionado;
        }

        public List<VehiculosXSede> SeleccionarXSede(Guid sede)
        {
            var itemSeleccionado = _db.VehiculosXSedes.Where(p => p.sedeId == sede).ToList();
            return itemSeleccionado;
        }
    }
}
