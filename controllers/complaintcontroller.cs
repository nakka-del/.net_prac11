using Microsoft.AspNetCore.Mvc;
using SmartCampusPortal.Data;
using SmartCampusPortal.Models;

namespace SmartCampusPortal.Controllers
{
    public class ComplaintController : Controller
    {
        private readonly CampusDbContext db;

        public ComplaintController(CampusDbContext context)
        {
            db = context;
        }

        public IActionResult Index()
        {
            var complaints = db.Complaints.ToList();

            return View(complaints);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Complaint complaint)
        {
            if (!ModelState.IsValid)
                return View(complaint);

            db.Complaints.Add(complaint);

            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var complaint = db.Complaints.Find(id);

            if (complaint != null)
            {
                db.Complaints.Remove(complaint);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}
