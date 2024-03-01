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
    public class SedeController : ControllerBase
    {
        SedeServicio CrearServicio()
        {
            MyDbContext db = new MyDbContext();
            SedeRepositorio repo = new SedeRepositorio(db);
            SedeServicio servicio = new SedeServicio(repo);
            return servicio;
        }
        // GET: api/<SedeController>
        [HttpGet]
        public ActionResult<List<Sede>> Get()
        {
            var serv = CrearServicio();
            return Ok(serv.Listar());
        }

        // GET api/<SedeController>/5
        [HttpGet("{id}")]
        public ActionResult<Sede> Get(Guid id)
        {
            var serv = CrearServicio();
            return Ok(serv.SeleccionarPorID(id));
        }

        // POST api/<SedeController>
        [HttpPost]
        public ActionResult Post([FromBody] Sede sede)
        {
            var serv = CrearServicio();
            serv.Agregar(sede);
            return Ok("Agregar satisfactoriamente");
        }
                
    }
}
