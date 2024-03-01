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
    public class VehiculoController : ControllerBase
    {
        VehiculoServicio CrearServicio()
        {
            MyDbContext db = new MyDbContext();
            VehiculoRepositorio repo = new VehiculoRepositorio(db);
            VehiculoServicio servicio = new VehiculoServicio(repo);
            return servicio;
        }
        // GET: api/<VehiculoController>
        [HttpGet]
        public ActionResult<List<Vehiculo>> Get()
        {
            var serv = CrearServicio();
            return Ok(serv.Listar());
        }

        // GET api/<VehiculoController>/5
        [HttpGet("{id}")]
        public ActionResult<Vehiculo> Get(Guid id)
        {
            var serv = CrearServicio();
            return Ok(serv.SeleccionarPorID(id));
        }

        // POST api/<VehiculoController>
        [HttpPost]
        public ActionResult Post([FromBody] Vehiculo vehiculo)
        {
            var serv = CrearServicio();
            serv.Agregar(vehiculo);
            return Ok("Agregar Satisfactoriamente");
        }

    }
}
