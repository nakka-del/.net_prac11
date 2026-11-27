using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartCampusPortal.Data;
using SmartCampusPortal.Models;

namespace SmartCampusPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CampusApiController : ControllerBase
    {
        private readonly CampusDbContext db;

        public CampusApiController(CampusDbContext context)
        {
            db = context;
        }

        [HttpGet("complaints")]
        public async Task<IActionResult> GetComplaints()
        {
            var data = await db.Complaints.ToListAsync();

            return Ok(data);
        }

        [HttpPost("complaints")]
        public async Task<IActionResult> AddComplaint(
            Complaint complaint)
        {
            db.Complaints.Add(complaint);

            await db.SaveChangesAsync();

            return Ok("Complaint Added Successfully");
        }

        [HttpPut("complaints/{id}")]
        public async Task<IActionResult> UpdateComplaint(
            int id, Complaint complaint)
        {
            var existing = await db.Complaints.FindAsync(id);

            if (existing == null)
                return NotFound();

            existing.Title = complaint.Title;
            existing.Description = complaint.Description;
            existing.Status = complaint.Status;

            await db.SaveChangesAsync();

            return Ok("Complaint Updated Successfully");
        }

        [HttpDelete("complaints/{id}")]
        public async Task<IActionResult> DeleteComplaint(int id)
        {
            var complaint = await db.Complaints.FindAsync(id);

            if (complaint == null)
                return NotFound();

            db.Complaints.Remove(complaint);

            await db.SaveChangesAsync();

            return Ok("Complaint Deleted Successfully");
        }
    }
}campus
