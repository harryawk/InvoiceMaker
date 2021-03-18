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
    public class CompanyController : ControllerBase
    {
        public readonly ApplicationDbContext _db;

        public CompanyController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _db.Companies.ToListAsync());
        }

        [HttpGet("detail/{id}")]
        public async Task<IActionResult> GetDetail(int id)
        {
            return Ok(await _db.Companies.FindAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Company company)
        {
            if (ModelState.IsValid)
            {
                await _db.Companies.AddAsync(company);
                await _db.SaveChangesAsync();
                return Accepted();
            }

            return BadRequest(new { Error = "Data tidak valid." });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Company company)
        {
            var comp = await _db.Companies.FindAsync(id);
            if (comp == null)
            {
                return BadRequest(new { Error = "Data tidak ditemukan" });
            }

            company.ID = id;
            if (ModelState.IsValid)
            {
                _db.Companies.Update(company);
                await _db.SaveChangesAsync();
                return Ok(company);
            }
            return Ok(id);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deletedData = await _db.Companies.FindAsync(id);
            if (deletedData == null)
            {
                return BadRequest(new { Error = "Data tidak ditemukan." });
            }

            _db.Companies.Remove(deletedData);
            await _db.SaveChangesAsync();

            return Ok();
        }
    }
}
