using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Domain;
using Domain.Entities;

namespace AdsWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Adverts1Controller : ControllerBase
    {
        private readonly AdsDBContext _context;

        public Adverts1Controller(AdsDBContext context)
        {
            _context = context;
        }

        // GET: api/Adverts1
        [HttpGet]
        public IEnumerable<Advert> GetAdverts()
        {
            return _context.Adverts;
        }

        // GET: api/Adverts1/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAdvert([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var advert = await _context.Adverts.FindAsync(id);

            if (advert == null)
            {
                return NotFound();
            }

            return Ok(advert);
        }

        // PUT: api/Adverts1/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdvert([FromRoute] int id, [FromBody] Advert advert)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != advert.Id)
            {
                return BadRequest();
            }

            _context.Entry(advert).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdvertExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Adverts1
        [HttpPost]
        public async Task<IActionResult> PostAdvert([FromBody] Advert advert)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Adverts.Add(advert);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAdvert", new { id = advert.Id }, advert);
        }

        // DELETE: api/Adverts1/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdvert([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var advert = await _context.Adverts.FindAsync(id);
            if (advert == null)
            {
                return NotFound();
            }

            _context.Adverts.Remove(advert);
            await _context.SaveChangesAsync();

            return Ok(advert);
        }

        private bool AdvertExists(int id)
        {
            return _context.Adverts.Any(e => e.Id == id);
        }
    }
}