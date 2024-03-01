using MilesCar.Aplicaciones.Interfaces;

using MilesCar.Dominio;
using MilesCar.Dominio.Interfaces.Repositorio;

namespace MilesCar.Aplicaciones.Servicios
{
    public class ConsultaServicio : IServicioBase<VehiculosXSede, Guid>
    {
        private IRepositorioBase<Vehiculo, Guid> _repoVehiculo;
        private IRepositorioBase<Sede, Guid> _repoSede;
        private IRepositorioVehiculoPorSede<VehiculosXSede, Guid> _repoVehiculoPorSede;
        private IConsultaRepositorio<ConsultaRequest, ConsultaResponse> _repoconsulta; 

        public ConsultaServicio(IRepositorioBase<Vehiculo, Guid> repovehiculo,
             IRepositorioBase<Sede, Guid> repoSede,
            IRepositorioVehiculoPorSede<VehiculosXSede, Guid> repovehiculoPorSede,
            IConsultaRepositorio<ConsultaRequest, ConsultaResponse> repoconsulta)
        {
            _repoVehiculo = repovehiculo;
            _repoSede = repoSede;
            _repoVehiculoPorSede = repovehiculoPorSede;
            _repoconsulta = repoconsulta;
        }

        public VehiculosXSede Agregar(VehiculosXSede entidad)
        {
            if (entidad == null) throw new ArgumentNullException("El 'Vehículo por Sede' es requrido");

            var Vehiculo = _repoVehiculo.SeleccionarPorID(entidad.vehiculoId);
            if (Vehiculo == null) throw new ArgumentException("Está tratando de guardar un vehículo que no existe en la base de datos");

            var Sede = _repoSede.SeleccionarPorID(entidad.sedeId);
            if (Sede == null) throw new ArgumentException("Está tratando de guardar una sede que no existe en la base de datos");

            var result = _repoVehiculoPorSede.Agregar(entidad);
            _repoVehiculoPorSede.GuardarTodosLosCambios();
            return result;
        }

        public List<VehiculosXSede> Listar()
        {
            return _repoVehiculoPorSede.Listar();
        }

        public VehiculosXSede SeleccionarPorID(Guid entidadId)
        {
            return _repoVehiculoPorSede.SeleccionarPorID(entidadId);
        }

        public List<VehiculosXSede> SeleccionarVehiculosPorSede(Guid Sede)
        {
            return _repoVehiculoPorSede.SeleccionarXSede(Sede);
        } 

        public ConsultaResponse ConsultaVehiculosDisponiles(ConsultaRequest request)
        {
            return _repoconsulta.ConsultaVehiculosDis(request);
        }
    }
}
