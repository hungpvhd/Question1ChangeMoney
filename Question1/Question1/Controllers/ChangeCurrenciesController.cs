using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Question1.Data;
using Question1.Models;

namespace Question1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChangeCurrenciesController : ControllerBase
    {
        private readonly Question1Context _context;

        public ChangeCurrenciesController(Question1Context context)
        {
            _context = context;
        }

        // GET: api/ChangeCurrencies
        [HttpGet]
        public IEnumerable<ChangeCurrency> GetChangeCurrency()
        {
            return _context.ChangeCurrency;
        }

        // GET: api/ChangeCurrencies/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetChangeCurrency([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var changeCurrency = await _context.ChangeCurrency.FindAsync(id);

            if (changeCurrency == null)
            {
                return NotFound();
            }

            return Ok(changeCurrency);
        }

        // PUT: api/ChangeCurrencies/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutChangeCurrency([FromRoute] int id, [FromBody] ChangeCurrency changeCurrency)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != changeCurrency.Id)
            {
                return BadRequest();
            }

            _context.Entry(changeCurrency).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChangeCurrencyExists(id))
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

        // POST: api/ChangeCurrencies
        [HttpPost]
        public async Task<IActionResult> PostChangeCurrency([FromBody] ChangeCurrency changeCurrency)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ChangeCurrency.Add(changeCurrency);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetChangeCurrency", new { id = changeCurrency.Id }, changeCurrency);
        }

        // DELETE: api/ChangeCurrencies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChangeCurrency([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var changeCurrency = await _context.ChangeCurrency.FindAsync(id);
            if (changeCurrency == null)
            {
                return NotFound();
            }

            _context.ChangeCurrency.Remove(changeCurrency);
            await _context.SaveChangesAsync();

            return Ok(changeCurrency);
        }

        private bool ChangeCurrencyExists(int id)
        {
            return _context.ChangeCurrency.Any(e => e.Id == id);
        }
    }
}