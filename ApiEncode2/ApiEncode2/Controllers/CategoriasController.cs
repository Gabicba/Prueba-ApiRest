using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiEncode2.Context;
using ApiEncode2.Models;
using AutoMapper;
using ApiEncode2.DTOs;

namespace ApiEncode2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;



        public CategoriasController(AppDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Categorias
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoriaDTO>>> Getall()
        {
            var categoria = await _context.Categorias.ToListAsync();
            return Ok(_mapper.Map<IEnumerable<CategoriaDTO>>(categoria));

        }

        // GET: api/Categorias/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoriaDTO>>GetById(int id)
        {
            var categoria = await _context.Categorias.FindAsync(id);

            if (categoria == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<CategoriaDTO>(categoria));
        }

   

        // POST: api/Categorias
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult> Create(CategoriaDTO dTO)
        {
           var categoria = _mapper.Map<Categoria>(dTO);
            _context.Categorias.Add(categoria);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = categoria.Id }, dTO);
            
        }

        // DELETE: api/Categorias/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var categoria = await _context.Categorias.Include(c => c.Productos).FirstOrDefaultAsync(c => c.Id ==id);
            if (categoria == null)
            {
                return NotFound();
            }
            if (categoria.Productos.Any()) return BadRequest("no se puede eliminar porque tiene productos cargados esta categoria");
            _context.Categorias.Remove(categoria);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CategoriaExists(int id)
        {
            return _context.Categorias.Any(e => e.Id == id);
        }
    }
}
