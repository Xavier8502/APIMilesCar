using MilesCar.Aplicaciones.Interfaces;
using MilesCar.Dominio;
using MilesCar.Dominio.Interfaces.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilesCar.Aplicaciones.Servicios
{
    public class VehiculoServicio : IServicioBase<Vehiculo, Guid>
    {
        private readonly IRepositorioBase<Vehiculo, Guid> repo;

        public VehiculoServicio(IRepositorioBase<Vehiculo, Guid> repositorio)
        {
            repo = repositorio;
        }

        public Vehiculo Agregar(Vehiculo entidad)
        {
            if (entidad == null)
                throw new ArgumentNullException("El 'Vehículo' es requerida");

            var result = repo.Agregar(entidad);
            repo.GuardarTodosLosCambios();
            return result;
        }

        public List<Vehiculo> Listar()
        {
            return repo.Listar();
        }

        public Vehiculo SeleccionarPorID(Guid entidadId)
        {
            return repo.SeleccionarPorID(entidadId);
        }

    }
}
