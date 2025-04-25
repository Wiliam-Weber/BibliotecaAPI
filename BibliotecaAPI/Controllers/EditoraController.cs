    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using BibliotecaAPI.Data;
    using BibliotecaAPI.Models;

    namespace BibliotecaAPI.Controllers
    {
        [Route("api/[controller]")]
        [ApiController]
        public class EditoraController : ControllerBase
        {
            private readonly BibliotecaContext _context;

            public EditoraController(BibliotecaContext context)
            {
                _context = context;
            }

            [HttpGet]
            public async Task<ActionResult<IEnumerable<Editora>>> GetEditoras()
            {
            return await _context.Editoras
            .Include(l => l.Livros)
            .ToListAsync();
            
            
        }

            [HttpGet("{id}")]
            public async Task<ActionResult<Editora>> GetEditora(int id)
            {
                var editora = await _context.Editoras.FindAsync(id);
                if (editora == null)
                    return NotFound();

                return editora;
            }

            [HttpPost]
            public async Task<ActionResult<Editora>> PostEditora(Editora editora)
            {
                _context.Editoras.Add(editora);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetEditora), new { id = editora.Id }, editora);
            }

            [HttpPut("{id}")]
            public async Task<IActionResult> PutEditora(int id, Editora editora)
            {
                if (id != editora.Id)
                    return BadRequest();

                _context.Entry(editora).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return NoContent();
            }

            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteEditora(int id)
            {
                var editora = await _context.Editoras.FindAsync(id);
                if (editora == null)
                    return NotFound();

                _context.Editoras.Remove(editora);
                await _context.SaveChangesAsync();
                return NoContent();
            }
        }
    }
