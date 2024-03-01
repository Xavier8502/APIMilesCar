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
    public class SedeRepositorio : IRepositorioBase<Sede, Guid>
    {
        private MyDbContext _db;

        public SedeRepositorio(MyDbContext dbContext)
        {
            _db = dbContext;
        }

        public Sede Agregar(Sede entidad)
        {
            entidad.id = Guid.NewGuid();
            _db.Sedes.Add(entidad);
            return entidad;
        }

        public void GuardarTodosLosCambios()
        {
            _db.SaveChanges();
        }

        public List<Sede> Listar()
        {
            var lista = _db.Sedes.ToList();
            lista.ForEach(sede =>
            {
                sede.localidad = _db.Localidades.Where(p => p.id == sede.localidadId).FirstOrDefault();        
            });

            return lista;
        }

        public Sede SeleccionarPorID(Guid entidadId)
        {
            var sedeSeleccionada = _db.Sedes.Where(p => p.id == entidadId).FirstOrDefault();
            sedeSeleccionada.localidad = _db.Localidades.Where(p => p.id == sedeSeleccionada.localidadId).FirstOrDefault();          
            return sedeSeleccionada;
        }
    }
}
