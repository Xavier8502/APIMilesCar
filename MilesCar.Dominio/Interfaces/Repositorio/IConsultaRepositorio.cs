using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilesCar.Dominio.Interfaces.Repositorio
{
    public interface IConsultaRepositorio <TEntidadReq,TEndidadRes>
    {
        TEndidadRes ConsultaVehiculosDis(TEntidadReq tentidadreq);
    }
}
