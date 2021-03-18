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
    public class InvoiceController : ControllerBase
    {
        public readonly ApplicationDbContext _db;

        public InvoiceController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _db.Invoices
                .Include(i => i.Language)
                .Include(i => i.PurchaseOrder)
                .Include(i => i.Company)
                .Include(i => i.Currency)
                .ToListAsync());
        }

        [HttpGet("detail/{id}")]
        public async Task<IActionResult> GetDetail(int id)
        {
            return Ok(await _db.Invoices.FindAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Invoice invoice)
        {
            if (ModelState.IsValid)
            {
                await _db.Invoices.AddAsync(invoice);
                await _db.SaveChangesAsync();
                return Accepted();
            }

            return BadRequest(new { Error = "Data tidak valid." });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Invoice invoice)
        {
            var inv = await _db.Invoices.FindAsync(id);
            if (inv == null)
            {
                return BadRequest(new { Error = "Data tidak ditemukan" });
            }

            invoice.ID = id;
            if (ModelState.IsValid)
            {
                _db.Invoices.Update(invoice);
                await _db.SaveChangesAsync();
                return Ok(invoice);
            }
            return Ok(id);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deletedData = await _db.Invoices.FindAsync(id);
            if (deletedData == null)
            {
                return BadRequest(new { Error = "Data tidak ditemukan." });
            }

            _db.Invoices.Remove(deletedData);
            await _db.SaveChangesAsync();

            return Ok();
        }
    }
}
