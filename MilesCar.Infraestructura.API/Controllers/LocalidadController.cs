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
    public class LocalidadController : ControllerBase
    {
        LocalidadServicio CrearServicio()
        {
            MyDbContext db = new MyDbContext();
            LocalidadRepositorio repo = new LocalidadRepositorio(db);
            LocalidadServicio servicio = new LocalidadServicio(repo);
            return servicio;
        }
        // GET: api/<LocalidadController>
        [HttpGet]
        public ActionResult<List<Localidad>> Get()
        {
            var servicio = CrearServicio();
            return Ok(servicio.Listar());
        }

        // GET api/<LocalidadController>/5
        [HttpGet("{id}")]
        public ActionResult<Localidad> Get(Guid id)
        {
            var serv = CrearServicio();
            return Ok(serv.SeleccionarPorID(id));
        }

        // POST api/<LocalidadController>
        [HttpPost]
        public ActionResult Post([FromBody] Localidad localidad)
        {
            var serv = CrearServicio();
            serv.Agregar(localidad);
            return Ok("Agregar Satisfactoriamente");
        }        
    }
}
