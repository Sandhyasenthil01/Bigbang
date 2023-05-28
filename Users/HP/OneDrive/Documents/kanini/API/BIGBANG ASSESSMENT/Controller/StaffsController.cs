using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BIGBANG_ASSESSMENT.DB;
using BIGBANG_ASSESSMENT.Models;
using System.Text;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace BIGBANG_ASSESSMENT.Controller
{
    [Authorize(Roles = "Staff")]
    [Route("api/[controller]")]
    [ApiController]
    public class StaffsController : ControllerBase
    {
        private readonly HotelContext _context;

        public StaffsController(HotelContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Staff>>> GetStaff()
        {
            var staff = await _context.Staff.ToListAsync();
            var GetStaff = staff
                .Select(s => new Staff
            {
                StaffId = s.StaffId,
                StaffName = s.StaffName,
                StaffPassword = HashPassword(s.StaffPassword)
            }).ToList();
            return GetStaff;
        }

        // GET: api/Staffs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Staff>> GetStaffById(int id)
        {
            if (_context.Staff == null)
            {
                return NotFound();
            }

            var staff = await _context.Staff.FindAsync(id);

            if (staff == null)
            {
                return NotFound();
            }

            var getStaff = new Staff
            {
                StaffId = staff.StaffId,
                StaffName = staff.StaffName,
                StaffPassword = HashPassword(staff.StaffPassword),
            };

            return getStaff;
        }

        // PUT: api/Staffs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStaff(int id, Staff staff)
        {
            if (id != staff.StaffId)
            {
                return BadRequest();
            }

            _context.Entry(staff).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StaffExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Staffs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Staff>> PostStaff(Staff staff)
        {
          if (_context.Staff == null)
          {
              return Problem("Entity set 'HotelContext.Staff'  is null.");
          }
            _context.Staff.Add(staff);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStaff", new { id = staff.StaffId }, staff);
        }

        // DELETE: api/Staffs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStaff(int id)
        {
            if (_context.Staff == null)
            {
                return NotFound();
            }
            var staff = await _context.Staff.FindAsync(id);
            if (staff == null)
            {
                return NotFound();
            }

            _context.Staff.Remove(staff);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        private string HashPassword(string StaffPassword)
        {
          
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(StaffPassword));
                return Convert.ToBase64String(hashedBytes);
            }
        }
        private bool StaffExists(int id)
        {
            return (_context.Staff?.Any(e => e.StaffId == id)).GetValueOrDefault();
        }
    }
}
