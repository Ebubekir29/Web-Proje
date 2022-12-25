using Microsoft.AspNetCore.Mvc;
using MvcWebProje.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MvcWebProje.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class YemekApiController : ControllerBase
    {
        private readonly DatabaseContext _databaseContext;
        public YemekApiController(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
        // GET: api/<YemekApiController>
        [HttpGet]
        public IEnumerable<Yemekler> Get()
        {
            return _databaseContext.yemeklers.ToList();
        }

        // GET api/<YemekApiController>/5
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var yemek = _databaseContext.yemeklers.Where(p => p.id == id).FirstOrDefault();
            if (yemek == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(yemek);
            }


        }

        // POST api/<YemekApiController>
        [HttpPost]
        public IActionResult Post([FromBody] Yemekler newYemek)
        {
            var yemekIsmi = newYemek != null ? newYemek.yemekIsmi : "";
            var yemekIsmi1 = newYemek != null ? newYemek.yemeginKategorisi : "";
            var yemekIsmi2 = newYemek != null ? newYemek.YemekTarifi : "";
            var yemekIsmi3 = newYemek != null ? newYemek.CreatedAt : new System.DateTime { };

            if (newYemek != null)
            {
                _databaseContext.yemeklers.Add(newYemek);
                _databaseContext.SaveChanges();
            }

            return Ok(yemekIsmi);
        }

        // PUT api/<YemekApiController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<YemekApiController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
