using CiudadesTiempoAPI.Data;
using CiudadesTiempoAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CiudadesTiempoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaisController : ControllerBase
    {
        private readonly Basecontext _db;

        public PaisController(Basecontext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> GetPais()
        {
            var lista = await _db.Paises.OrderBy(p => p.NombrePais).Include(p => p.Ciudad).ToListAsync();

            return Ok(lista);

        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetPais(int id)
        {
            var obj = await _db.Paises.Include(p => p.Ciudad).FirstOrDefaultAsync(p=>p.Id==id);

            if (obj == null)
            {

                return NotFound();
            }

            return Ok(obj);

        }

        [HttpPost]
        public async Task<IActionResult> CrearPais([FromBody] Pais pais)
        {
            if (pais == null)
            {
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _db.AddAsync(pais);
            await _db.SaveChangesAsync();

            return Ok();
        }
    }
}
