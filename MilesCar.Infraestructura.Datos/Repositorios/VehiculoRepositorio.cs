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
    public class VehiculoRepositorio : IRepositorioBase<Vehiculo, Guid>
    {
        private MyDbContext _db;

        public VehiculoRepositorio(MyDbContext dbContext)
        {
            _db = dbContext;
        }

        public Vehiculo Agregar(Vehiculo entidad)
        {
            entidad.id = Guid.NewGuid();
            _db.Vehiculos.Add(entidad);
            return entidad;
        }

        public void GuardarTodosLosCambios()
        {
            _db.SaveChanges();
        }

        public List<Vehiculo> Listar()
        {
            var lista = _db.Vehiculos.ToList();
        
            return lista;
        }

        public Vehiculo SeleccionarPorID(Guid entidadId)
        {
            var vehiculoSeleccionado = _db.Vehiculos.Where(p=> p.id == entidadId).ToList().FirstOrDefault();
            return vehiculoSeleccionado;
        }
    }
}
