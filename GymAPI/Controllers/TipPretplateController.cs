using GymAPI.DTOs;
using GymAPI.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GymAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipPretplateController : ControllerBase
    {
        private readonly Gyms4usContext _context;

        public TipPretplateController(Gyms4usContext context)
        {
            _context = context;
        }


        // GET: api/<TipPretplateController>
        [HttpGet]
        public ActionResult<IEnumerable<TipPretplateDTO>> Get()
        {
            try
            {
                var result = _context.TipPretplates;
                var mappedResult = result.Select(x =>
                new TipPretplateDTO
                {
                    Id = x.Id,
                    Naziv = x.Naziv,
                    Trajanje = x.Trajanje,
                    Cijena = x.Cijena
                });

                return Ok(mappedResult);
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }

        // GET api/<TipPretplateController>/5
        [HttpGet("{id}")]
        public ActionResult<TipPretplateDTO> Get(int id)
        {
            try
            {
                var result = _context.TipPretplates.FirstOrDefault(x => x.Id == id);

                var mappedResult = new TipPretplateDTO
                {
                   Id = result.Id,
                   Naziv = result.Naziv,
                   Trajanje = result.Trajanje,
                   Cijena = result.Cijena
                };

                return Ok(mappedResult);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // POST api/<TipPretplateController>
        [HttpPost]
        public ActionResult<TipPretplateDTO> Post([FromBody]TipPretplateDTO tipPretplate)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var newTipPretplate = new TipPretplate
                {
                    Naziv = tipPretplate.Naziv,
                    Trajanje = tipPretplate.Trajanje,
                    Cijena = tipPretplate.Cijena
                };

                _context.TipPretplates.Add(newTipPretplate);
                _context.SaveChanges();
                tipPretplate.Id = newTipPretplate.Id;
                return Ok(tipPretplate);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        // PUT api/<TipPretplateController>/5
        [HttpPut("{id}")]
        public ActionResult<TipPretplateDTO> Put(int id, [FromBody]TipPretplateDTO tipPretplate)
        {
            try
            {
                var result = _context.TipPretplates.FirstOrDefault(x => x.Id == id);

                result.Naziv = tipPretplate.Naziv;
                result.Trajanje = tipPretplate.Trajanje;
                result.Cijena = tipPretplate.Cijena;

                _context.SaveChanges();

                return Ok(tipPretplate);
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }

        // DELETE api/<TipPretplateController>/5
        [HttpDelete("{id}")]
        public ActionResult<TipPretplateDTO> Delete(int id)
        {
            try
            {
                var result = _context.TipPretplates.FirstOrDefault(x => x.Id == id);
                _context.TipPretplates.Remove(result);
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
