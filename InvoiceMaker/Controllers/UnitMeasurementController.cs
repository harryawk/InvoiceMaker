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
    public class UnitMeasurementController : ControllerBase
    {
        public readonly ApplicationDbContext _db;

        public UnitMeasurementController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _db.UnitMeasurements.ToListAsync());
        }

        [HttpGet("detail/{id}")]
        public async Task<IActionResult> GetDetail(int id)
        {
            return Ok(await _db.UnitMeasurements.FindAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UnitMeasurement unit)
        {
            if (ModelState.IsValid)
            {
                await _db.UnitMeasurements.AddAsync(unit);
                await _db.SaveChangesAsync();
                return Accepted();
            }

            return BadRequest(new { Error = "Data tidak valid." });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UnitMeasurement unit)
        {
            var measurement = await _db.UnitMeasurements.FindAsync(id);
            if (measurement == null)
            {
                return BadRequest(new { Error = "Data tidak ditemukan" });
            }

            unit.ID = id;
            if (ModelState.IsValid)
            {
                _db.UnitMeasurements.Update(unit);
                await _db.SaveChangesAsync();
                return Ok(unit);
            }
            return Ok(id);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deletedData = await _db.UnitMeasurements.FindAsync(id);
            if (deletedData == null)
            {
                return BadRequest(new { Error = "Data tidak ditemukan." });
            }

            _db.UnitMeasurements.Remove(deletedData);
            await _db.SaveChangesAsync();

            return Ok();
        }
    }
}
