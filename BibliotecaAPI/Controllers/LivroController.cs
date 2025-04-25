using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BibliotecaAPI.Data;
using BibliotecaAPI.Models;

namespace BibliotecaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivroController : ControllerBase
    {
        private readonly BibliotecaContext _context;

        public LivroController(BibliotecaContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Livro>>> GetLivros()
        {
            var livro = await _context.Livros
                .Include(l => l.Editora)
                .Include(l => l.Autor)
                .FirstAsync();
                

            if (livro == null)
            {
                return NotFound();
            }
            return Ok(livro);
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<Livro>> GetLivro(int id)
        {
            var livro = await _context.Livros
            .Include(l => l.Editora) 
            .Include(l => l.Autor)   
            .FirstOrDefaultAsync(l => l.Id == id);
            if (livro == null)
            {
                return NotFound();
            }
            return Ok(livro);
        }
        
        [HttpPost]
        public async Task<ActionResult<Livro>> PostLivro(Livro livro)
        {
            _context.Livros.Add(livro);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetLivro), new { id = livro.Id }, livro);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutLivro(int id, Livro livro)
        {
            if (id != livro.Id)
                return BadRequest();

            _context.Entry(livro).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLivro(int id)
        {
            var livro = await _context.Livros.FindAsync(id);
            if (livro == null)
                return NotFound();

            _context.Livros.Remove(livro);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
