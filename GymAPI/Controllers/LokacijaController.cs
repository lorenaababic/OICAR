using GymAPI.DTOs;
using GymAPI.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GymAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LokacijaController : ControllerBase
    {
        private readonly Gyms4usContext _context;

        public LokacijaController(Gyms4usContext context)
        {
            _context = context;
        }

        // GET: api/<LokacijaController>
        [HttpGet]
        public ActionResult<IEnumerable<LokacijaDTO>> Get()
        {
            try
            {
                var result = _context.Lokacijas;
                var mappedResult = result.Select(x =>
                new LokacijaDTO
                {
                    Id = x.Id,
                    Ime = x.Ime,
                    Adresa = x.Adresa,
                    Latitude = x.Latitude,
                    Longitude = x.Longitude
                });

                return Ok(mappedResult);
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }

        // GET api/<LokacijaController>/5
        [HttpGet("{id}")]
        public ActionResult<LokacijaDTO> Get(int id)
        {
            try
            {
                var result = _context.Lokacijas.FirstOrDefault(x => x.Id == id);

                var mappedResult = new LokacijaDTO
                {
                    Id = result.Id,
                    Ime = result.Ime,
                    Adresa = result.Adresa,
                    Latitude = result.Latitude,
                    Longitude = result.Longitude
                };

                return Ok(mappedResult);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // POST api/<LokacijaController>
        [HttpPost]
        public ActionResult<LokacijaDTO> Post([FromBody] LokacijaDTO lokacija)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var newLokacija = new Lokacija
                {
                    Ime = lokacija.Ime,
                    Adresa = lokacija.Adresa,
                    Latitude = lokacija.Latitude,
                    Longitude = lokacija.Longitude
                };

                _context.Lokacijas.Add(newLokacija);
                _context.SaveChanges();
                lokacija.Id = newLokacija.Id;
                return Ok(lokacija);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        // PUT api/<LokacijaController>/5
        [HttpPut("{id}")]
        public ActionResult<LokacijaDTO> Put(int id, [FromBody] LokacijaDTO lokacija)
        {
            try
            {
                var result = _context.Lokacijas.FirstOrDefault(x => x.Id == id);

                result.Ime = lokacija.Ime;
                result.Adresa = lokacija.Adresa;
                result.Longitude = lokacija.Longitude;
                result.Latitude = lokacija.Latitude;

                _context.SaveChanges();

                return Ok(lokacija);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // DELETE api/<LokacijaController>/5
        [HttpDelete("{id}")]
        public ActionResult<LokacijaDTO> Delete(int id)
        {
            try
            {
                var result = _context.Lokacijas.FirstOrDefault(x => x.Id == id);

                _context.Lokacijas.Remove(result);
                _context.SaveChanges();

                return Ok();
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message); 
            }
        }
    }
}
