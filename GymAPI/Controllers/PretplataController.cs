using GymAPI.DTOs;
using GymAPI.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GymAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PretplataController : ControllerBase
    {
        private readonly Gyms4usContext _context;

        public PretplataController(Gyms4usContext context)
        {
            _context = context;
        }



        // GET: api/<PretplataController>
        [HttpGet]
        public ActionResult<IEnumerable<PretplataDTO>> Get()
        {
            try
            {
                var result = _context.Pretplatas;
                var mappedResult = result.Select(x =>
                new PretplataDTO
                {
                    Id = x.Id,
                    TipPretplateid = x.TipPretplateid,
                    DatumPocetka = x.DatumPocetka,
                    DatumZavrsetka = x.DatumZavrsetka
                });

                return Ok(mappedResult);
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }

        // GET api/<PretplataController>/5
        [HttpGet("{id}")]
        public ActionResult<PretplataDTO> Get(int id)
        {
            try
            {
                var result = _context.Pretplatas.FirstOrDefault(x => x.Id == id);

                var mappedResult = new PretplataDTO
                {
                    Id = result.Id,
                    TipPretplateid = result.TipPretplateid,
                    DatumPocetka = result.DatumPocetka,
                    DatumZavrsetka = result.DatumZavrsetka
                };

                return Ok(mappedResult);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // POST api/<PretplataController>
        [HttpPost]
        public ActionResult<PretplataDTO> Post([FromBody]PretplataDTO pretplata)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var newPretplata = new Pretplata
                {
                    TipPretplateid = pretplata.TipPretplateid,
                    DatumPocetka = pretplata.DatumPocetka,
                    DatumZavrsetka = pretplata.DatumZavrsetka
                };

                _context.Pretplatas.Add(newPretplata);
                _context.SaveChanges();
                pretplata.Id = newPretplata.Id;
                return Ok(pretplata);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        // PUT api/<PretplataController>/5
        [HttpPut("{id}")]
        public ActionResult<PretplataDTO> Put(int id, [FromBody]PretplataDTO pretplata)
        {
            try
            {
                var result = _context.Pretplatas.FirstOrDefault(x => x.Id == id);

                result.TipPretplateid = pretplata.TipPretplateid;
                result.DatumPocetka = pretplata.DatumPocetka;
                result.DatumZavrsetka = pretplata.DatumZavrsetka;

                _context.SaveChanges();

                return Ok(pretplata);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // DELETE api/<PretplataController>/5
        [HttpDelete("{id}")]
        public ActionResult<PretplataDTO> Delete(int id)
        {
            try
            {
                var result = _context.Pretplatas.FirstOrDefault(x => x.Id == id);
                _context.Pretplatas.Remove(result);
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
