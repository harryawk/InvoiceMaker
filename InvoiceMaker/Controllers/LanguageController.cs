using InvoiceMaker.Data;
using InvoiceMaker.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceMaker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguageController : ControllerBase
    {
        public readonly ApplicationDbContext _db;

        public LanguageController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _db.Languages.ToListAsync());
        }

        [HttpGet("detail/{id}")]
        public async Task<IActionResult> GetDetail(int id)
        {
            return Ok(await _db.Languages.FindAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Language language)
        {
            if (ModelState.IsValid)
            {
                await _db.Languages.AddAsync(language);
                await _db.SaveChangesAsync();
                return Accepted();
            }

            return BadRequest(new { Error = "Data tidak valid." });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Language language)
        {
            if (ModelState.IsValid)
            {
                _db.Languages.Update(language);
                await _db.SaveChangesAsync();
                return Ok(language);
            }
            return Ok(id);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var oldData = await _db.Languages.FindAsync(id);
            if (oldData == null)
            {
                return BadRequest(new { Error = "Data tidak ditemukan." });
            }

            _db.Languages.Remove(oldData);
            await _db.SaveChangesAsync();

            return Ok();
        }

    }
}
