using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MilesCar.Dominio;
using MilesCar.Dominio.Interfaces;
using MilesCar.Aplicaciones.Interfaces;
using MilesCar.Dominio.Interfaces.Repositorio;

namespace MilesCar.Aplicaciones.Servicios
{
    public class LocalidadServicio : IServicioBase<Localidad, Guid>
    {
        private readonly IRepositorioBase<Localidad, Guid> repo;

        public LocalidadServicio(IRepositorioBase<Localidad, Guid> repositorio )
        {
            repo = repositorio;
        }
        public Localidad Agregar(Localidad entidad)
        {
            if (entidad == null)
                throw new ArgumentNullException("La 'Localidad' es requerida");

            var result = repo.Agregar(entidad);
            repo.GuardarTodosLosCambios();
            return result;
        }

        public List<Localidad> Listar()
        {
            return repo.Listar();
        }

        public Localidad SeleccionarPorID(Guid entidadId)
        {
            return repo.SeleccionarPorID(entidadId);
        }
    }
}
