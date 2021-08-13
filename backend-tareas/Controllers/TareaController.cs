using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend_tareas.Context;
using backend_tareas.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend_tareas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TareaController : ControllerBase
    {
        private readonly AplicationDbContext _context;
        public TareaController(AplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var listTareas = await _context.Notacs.ToListAsync();
                return Ok(listTareas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Notacs dbnotesapp)
        {
            try
            {
                _context.Notacs.Add(dbnotesapp);
                await _context.SaveChangesAsync();
                return Ok(new { message = "La tarea fue registrada con exito!" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Notacs dbnotesapp)
        {
            try
            {
                if(id != dbnotesapp.Id)
                {
                    return NotFound();
                }
                dbnotesapp.Title = dbnotesapp.Title;
                dbnotesapp.Descript = dbnotesapp.Descript;
                dbnotesapp.CreationDate = dbnotesapp.CreationDate;
                dbnotesapp.ExpirationDate = dbnotesapp.ExpirationDate;
                _context.Entry(dbnotesapp).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return Ok(new { message = "La tarea fue actualizada con exito!" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var tarea = await _context.Notacs.FindAsync(id);
                if(tarea == null)
                {
                    return NotFound();
                }
                _context.Notacs.Remove(tarea);
                await _context.SaveChangesAsync();
                return Ok(new { message = "Tarea eliminada con exito!" });

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
