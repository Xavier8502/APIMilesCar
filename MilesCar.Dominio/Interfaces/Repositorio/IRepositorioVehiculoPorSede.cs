using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilesCar.Dominio.Interfaces.Repositorio
{
    public interface IRepositorioVehiculoPorSede<TEntidad, TEntidadID>
        :IAgregar<TEntidad>, IListar<TEntidad, TEntidadID>, ITransaccion
    {
        List<TEntidad> SeleccionarXSede(TEntidadID sede);
    }
}
