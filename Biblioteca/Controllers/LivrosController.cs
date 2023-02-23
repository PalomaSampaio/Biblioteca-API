using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Biblioteca;
using Biblioteca.Data;

namespace Biblioteca.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivrosController : ControllerBase
    {
        private readonly DataContext _context;

        public LivrosController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Livros>>> GetCadastroLivros()
        {
            return await _context.CadastroLivros.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Livros>> GetLivros(int id)
        {
            var livros = await _context.CadastroLivros.FindAsync(id);

            if (livros == null)
            {
                return NotFound();
            }

            return livros;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutLivros(int id, Livros livros)
        {
            if (id != livros.Id)
            {
                return BadRequest();
            }

            _context.Entry(livros).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LivrosExists(id))
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

        [HttpPost]
        public async Task<ActionResult<Livros>> PostLivros(Livros livros)
        {
            _context.CadastroLivros.Add(livros);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLivros", new { id = livros.Id }, livros);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLivros(int id)
        {
            var livros = await _context.CadastroLivros.FindAsync(id);
            if (livros == null)
            {
                return NotFound();
            }

            _context.CadastroLivros.Remove(livros);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LivrosExists(int id)
        {
            return _context.CadastroLivros.Any(e => e.Id == id);
        }
    }
}
