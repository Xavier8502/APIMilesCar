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
    public class LocalidadRepositorio : IRepositorioBase<Localidad, Guid>
    {
        private MyDbContext _db;

        public LocalidadRepositorio(MyDbContext myDb)
        {
            _db = myDb;
        }

        public Localidad Agregar(Localidad entidad)
        {
            entidad.id = Guid.NewGuid();
            _db.Localidades.Add(entidad);
            return entidad;
        }

        public void GuardarTodosLosCambios()
        {
            _db.SaveChanges();
        }

        public List<Localidad> Listar()
        {
            return _db.Localidades.ToList();
        }

        public Localidad SeleccionarPorID(Guid entidadId)
        {
            var localidadSeleccionada = _db.Localidades.Where(p => p.id == entidadId).FirstOrDefault();
            return localidadSeleccionada;
        }        
    }
}
