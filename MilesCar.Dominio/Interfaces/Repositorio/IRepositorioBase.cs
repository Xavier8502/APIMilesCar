using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilesCar.Dominio.Interfaces.Repositorio
{
    public interface IRepositorioBase<TEntidad, TEntidadID>:
        IAgregar<TEntidad>, IListar<TEntidad, TEntidadID>, ITransaccion
    {

    }
}
