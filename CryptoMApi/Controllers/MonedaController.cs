using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CryptoMApi.Contexto;
using CryptoMApi.Modelo;

namespace CryptoMApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MonedaController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public MonedaController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/Moneda
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Coin>>> GetCoin()
        {
            return await _context.Coin.ToListAsync();
        }

        // GET: api/Moneda/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Coin>> GetCoin(int id)
        {
            var coin = await _context.Coin.FindAsync(id);

            if (coin == null)
            {
                return NotFound();
            }

            return coin;
        }

        // PUT: api/Moneda/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCoin(int id, Coin coin)
        {
            if (id != coin.MonedaId)
            {
                return BadRequest();
            }

            _context.Entry(coin).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CoinExists(id))
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

        // POST: api/Moneda
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Coin>> PostCoin(Coin coin)
        {
            _context.Coin.Add(coin);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCoin", new { id = coin.MonedaId }, coin);
        }

        // DELETE: api/Moneda/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCoin(int id)
        {
            var coin = await _context.Coin.FindAsync(id);
            if (coin == null)
            {
                return NotFound();
            }

            _context.Coin.Remove(coin);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CoinExists(int id)
        {
            return _context.Coin.Any(e => e.MonedaId == id);
        }
    }
}
