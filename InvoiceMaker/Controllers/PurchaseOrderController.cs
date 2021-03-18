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
    public class PurchaseOrderController : ControllerBase
    {
        public readonly ApplicationDbContext _db;

        public PurchaseOrderController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _db.PurchaseOrders.ToListAsync());
        }

        [HttpGet("detail/{id}")]
        public async Task<IActionResult> GetDetail(int id)
        {
            return Ok(await _db.PurchaseOrders.FindAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PurchaseOrder order)
        {
            if (ModelState.IsValid)
            {
                await _db.PurchaseOrders.AddAsync(order);
                await _db.SaveChangesAsync();
                return Accepted();
            }

            return BadRequest(new { Error = "Data tidak valid." });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] PurchaseOrder order)
        {
            var po = await _db.PurchaseOrders.FindAsync(id);
            if (po == null)
            {
                return BadRequest(new { Error = "Data tidak ditemukan" });
            }

            order.ID = id;
            if (ModelState.IsValid)
            {
                _db.PurchaseOrders.Update(order);
                await _db.SaveChangesAsync();
                return Ok(order);
            }
            return Ok(id);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deletedData = await _db.PurchaseOrders.FindAsync(id);
            if (deletedData == null)
            {
                return BadRequest(new { Error = "Data tidak ditemukan." });
            }

            _db.PurchaseOrders.Remove(deletedData);
            await _db.SaveChangesAsync();

            return Ok();
        }
    }
}
