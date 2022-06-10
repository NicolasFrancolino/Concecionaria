using Concecionaria.Entity;
using Concecionaria.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Concecionaria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiculoController : ControllerBase
    {
        private readonly IUnitOfWork _context;
        private readonly ILogger<VehiculoController> _logger;

        public VehiculoController(IUnitOfWork context, ILogger<VehiculoController> logger )
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Vehiculo>> Get()
        {
            //_logger.LogDebug("");
            _logger.LogInformation("Get vehiculos");
            var entidad = _context.VehiculoRepo.GetAll();
            return Ok(entidad);
        }

        [HttpPost]
        public ActionResult Post([FromBody] Vehiculo vehiculo)
        {
            _context.VehiculoRepo.Insert(vehiculo);
            _context.Save();
            return Ok();
        }


        [HttpPut("{id}")]
        public ActionResult Put([FromBody] Vehiculo vehiculo, int id)
        {
            try
            {
                _context.VehiculoRepo.Update(vehiculo);
                _context.Save();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var entity = _context.VehiculoRepo.GetById(id);
            if (entity == null)
            {
                return NotFound();
            }
            _context.VehiculoRepo.Delete(id);
            _context.Save();

            return Ok();
        }
    }
}
