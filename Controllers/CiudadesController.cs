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
    public class CiudadesController : ControllerBase
    {
        private readonly Basecontext _db;

        public CiudadesController(Basecontext db)
        {
            _db = db;
        }

        [HttpGet]
        [ProducesResponseType(200, Type=typeof(List<Ciudad>))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetCiudades()
        {
            var lista = await _db.Ciudades.OrderBy(c => c.NombreCiudad).ToListAsync();

            return Ok(lista);
        }

        [HttpGet("{id:int}", Name = "GetCiudades")]
        [ProducesResponseType(200, Type = typeof(Ciudad))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetCiudades(int id)
        {
            var obj = await _db.Ciudades.FirstOrDefaultAsync(c => c.Id == id);
            if (obj==null)
            {
                return NotFound();
            }

            return Ok(obj);
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> CrearCiudad ([FromBody] Ciudad ciudad)
        {
            if (ciudad == null)
            {

                return BadRequest(ModelState);
            }
            if(!ModelState.IsValid)
            {

                return BadRequest(ModelState);
            }

            await _db.AddAsync(ciudad);
            await _db.SaveChangesAsync();

            return CreatedAtRoute("GetCiudades", new { id = ciudad.Id}, ciudad);

        }

    }
}
