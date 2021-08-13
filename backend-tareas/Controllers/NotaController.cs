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
    public class NotaController : ControllerBase
    {
        private readonly AplicationDbContext _context;
            public NotaController(AplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var listNotas = await _context.Notacs.ToListAsync();
                return Ok(listNotas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Notacs notacs)
        {
            try 
            {
                _context.Notacs.Add(notacs);
                await _context.SaveChangesAsync();
                return Ok(new { message = "Note added succesfully!" });
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Notacs notacs)
        {
            try 
            { 
                if(id != notacs.Id)
                {
                    return NotFound();
                }
                notacs.Title = notacs.Title;
                notacs.Descript = notacs.Descript;
                notacs.ExpirationDate = notacs.ExpirationDate;
                notacs.CreationDate = new DateTime();

                _context.Entry(notacs).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return Ok(new { message = "Note updated succesfully!" });
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try 
            {
                var nota = await _context.Notacs.FindAsync(id);
                if (nota == null)
                {
                    return NotFound();
                }
                _context.Notacs.Remove(nota);
                await _context.SaveChangesAsync();
                return Ok(new { message = "Note deleted succesfully!" });
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
