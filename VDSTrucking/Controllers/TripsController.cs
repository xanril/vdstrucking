using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VDSTrucking.Data;
using VDSTrucking.Models;

namespace VDSTrucking.Controllers
{
    public class TripsController : Controller
    {
        private readonly VDSDBContext _context;

        public TripsController(VDSDBContext context)
        {
            _context = context;    
        }

        // GET: Trips
        public async Task<IActionResult> Index()
        {
            var vDSDBContext = _context.Trips.Include(t => t.Driver).Include(t => t.Truck);
            return View(await vDSDBContext.ToListAsync());
        }

        // GET: Trips/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trip = await _context.Trips
                .Include(t => t.Driver)
                .Include(t => t.Truck)
                .SingleOrDefaultAsync(m => m.TripID == id);
            if (trip == null)
            {
                return NotFound();
            }

            return View(trip);
        }

        // GET: Trips/Create
        public IActionResult Create()
        {
            ViewData["DriverID"] = new SelectList(_context.Drivers, "DriverID", "FirstName");
            ViewData["TruckID"] = new SelectList(_context.Trucks, "TruckID", "TruckID");
            return View();
        }

        // POST: Trips/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TripID,Date,TruckID,DriverID")] Trip trip)
        {
            if (ModelState.IsValid)
            {
                _context.Add(trip);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["DriverID"] = new SelectList(_context.Drivers, "DriverID", "FirstName", trip.DriverID);
            ViewData["TruckID"] = new SelectList(_context.Trucks, "TruckID", "TruckID", trip.TruckID);
            return View(trip);
        }

        // GET: Trips/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trip = await _context.Trips.SingleOrDefaultAsync(m => m.TripID == id);
            if (trip == null)
            {
                return NotFound();
            }
            ViewData["DriverID"] = new SelectList(_context.Drivers, "DriverID", "FirstName", trip.DriverID);
            ViewData["TruckID"] = new SelectList(_context.Trucks, "TruckID", "TruckID", trip.TruckID);
            return View(trip);
        }

        // POST: Trips/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TripID,Date,TruckID,DriverID")] Trip trip)
        {
            if (id != trip.TripID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(trip);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TripExists(trip.TripID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            ViewData["DriverID"] = new SelectList(_context.Drivers, "DriverID", "FirstName", trip.DriverID);
            ViewData["TruckID"] = new SelectList(_context.Trucks, "TruckID", "TruckID", trip.TruckID);
            return View(trip);
        }

        // GET: Trips/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trip = await _context.Trips
                .Include(t => t.Driver)
                .Include(t => t.Truck)
                .SingleOrDefaultAsync(m => m.TripID == id);
            if (trip == null)
            {
                return NotFound();
            }

            return View(trip);
        }

        // POST: Trips/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var trip = await _context.Trips.SingleOrDefaultAsync(m => m.TripID == id);
            _context.Trips.Remove(trip);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool TripExists(int id)
        {
            return _context.Trips.Any(e => e.TripID == id);
        }
    }
}
