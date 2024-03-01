using Microsoft.AspNetCore.Mvc;
using MilesCar.Aplicaciones.Servicios;
using MilesCar.Dominio;
using MilesCar.Infraestructura.Datos.Contextos;
using MilesCar.Infraestructura.Datos.Repositorios;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MilesCar.Infraestructura.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiculoXSedeController : ControllerBase
    {
        ConsultaServicio CrearServicio()
        {
            MyDbContext db = new MyDbContext();
            VehiculoRepositorio vehiculoRepositorio = new VehiculoRepositorio(db);
            SedeRepositorio sedeRepositorio = new SedeRepositorio(db);
            VehiculoXSedeRepositorio vehiculoXSedeRepositorio = new VehiculoXSedeRepositorio(db);
            ConsultaRepositorio consultaRepositorio = new ConsultaRepositorio(db);
            ConsultaServicio servicio = new ConsultaServicio(vehiculoRepositorio,
                sedeRepositorio,
                vehiculoXSedeRepositorio, 
                consultaRepositorio);
            return servicio;
        }
        // GET: api/<ConsultaController>
        [HttpGet]
        public ActionResult<List<VehiculoXSedeRepositorio>> Get()
        {
            var serv = CrearServicio();
            return Ok(serv.Listar());
        }

        // GET api/<ConsultaController>/5
        [HttpGet("{id}")]
        public ActionResult<List<VehiculoXSedeRepositorio>> Get(Guid SedeId)
        {
            var serv = CrearServicio();
            return Ok(serv.SeleccionarVehiculosPorSede(SedeId));
        }

        // POST api/<ConsultaController>
        [HttpPost("create")]
        public ActionResult Post([FromBody] VehiculosXSede vehiculoXSede)
        {
            var serv = CrearServicio();
            serv.Agregar(vehiculoXSede);
            return Ok("Agregar Satisfactoriamente");
        }

        // POST api/<ConsultaController>
        [HttpPost("search")]
        public ActionResult<ConsultaResponse> ConsultaDisponibles([FromBody] ConsultaRequest request)
        {
            var serv = CrearServicio();
            return Ok(serv.ConsultaVehiculosDisponiles(request));
        }

    }
}
