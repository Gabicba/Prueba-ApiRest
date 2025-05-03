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
using Humanizer;

namespace ApiEncode2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public ProductoController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Producto
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductoDTO>>> GetAll()
        {
            var productos = await _context.Productos.Include(p => p.Categoria).ToListAsync();
            return Ok(_mapper.Map<IEnumerable<ProductoDTO>>(productos));

        }

        // GET: api/Producto/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductoDTO>> GetById(int id)
        {
            var producto = await _context.Productos.Include(p => p.Categoria).FirstOrDefaultAsync(p => p.Id == id);
            if (producto == null) return NotFound();
            return Ok(_mapper.Map<ProductoDTO>(producto));
        }

        // PUT: api/Producto/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ProductoCreateDTO dTO)
        {
            var producto = await _context.Productos.FindAsync(id);
            if (producto == null) return NotFound();

            if (!await _context.Categorias.AnyAsync(c => c.Id == dTO.CategoriaId))
                return BadRequest("La categoría especificada no existe.");

            _mapper.Map(dTO, producto);
            await _context.SaveChangesAsync();


            return NoContent();
        }

        // POST: api/Producto
        [HttpPost]
        public async Task<ActionResult<ProductoDTO>> Create(ProductoCreateDTO dTO)
        {
            if (!await _context.Categorias.AnyAsync(c => c.Id == dTO.CategoriaId))
                return BadRequest("La categoría especificada no existe.");

            var producto = _mapper.Map<Producto>(dTO);
            _context.Productos.Add(producto);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = producto.Id }, producto);

        }

        // DELETE: api/Producto/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete (int id)
        {
            var producto = await _context.Productos.FindAsync(id);
            if (producto == null)
            {
                return NotFound();
            }

            _context.Productos.Remove(producto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductoExists(int id)
        {
            return _context.Productos.Any(e => e.Id == id);
        }
    }
}
