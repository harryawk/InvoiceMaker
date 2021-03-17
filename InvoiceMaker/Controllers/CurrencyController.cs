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
    public class CurrencyController : ControllerBase
    {

        public readonly ApplicationDbContext _db;

        public CurrencyController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _db.Currencies.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDetail(int id)
        {
            return Ok(await _db.Currencies.FindAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Currency currency)
        {
            if (ModelState.IsValid)
            {
                await _db.Currencies.AddAsync(currency);
                await _db.SaveChangesAsync();
                return Accepted();
            }
            return BadRequest(new { Error = "Data tidak valid" });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Currency currency)
        {
            var curr = await _db.Currencies.FindAsync(id);
            if (curr == null)
            {
                return BadRequest(new { Error = "Data tidak ditemukan" });
            }

            currency.ID = id;
            if (ModelState.IsValid)
            {
                _db.Currencies.Update(currency);
                await _db.SaveChangesAsync();
                return Ok();
            }

            return BadRequest(new { Error = "Data tidak ditemukan" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deletedData = await _db.Currencies.FindAsync(id);
            if (deletedData == null)
            {
                return BadRequest(new { Error = "Data tidak ditemukan" });
            }

            _db.Currencies.Remove(deletedData);
            await _db.SaveChangesAsync();
            return Ok();
        }
    }
}
