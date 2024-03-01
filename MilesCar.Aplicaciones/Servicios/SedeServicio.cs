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
    public class SedeServicio : IServicioBase<Sede, Guid>
    {
        private readonly IRepositorioBase<Sede, Guid> repo;

        public SedeServicio(IRepositorioBase<Sede, Guid> repositorio )
        {
            repo = repositorio;
        }

        public Sede Agregar(Sede entidad)
        {
            if (entidad == null)
                throw new ArgumentNullException("La 'Sede' es requerida");

            var result = repo.Agregar(entidad);
            repo.GuardarTodosLosCambios();
            return result;
        }

        public List<Sede> Listar()
        {
            return repo.Listar();
        }

        public Sede SeleccionarPorID(Guid entidadId)
        {
            return repo.SeleccionarPorID(entidadId);
        }
    }
}
