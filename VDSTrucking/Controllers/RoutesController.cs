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
    public class RoutesController : Controller
    {
        private readonly VDSDBContext _context;

        public RoutesController(VDSDBContext context)
        {
            _context = context;    
        }

        // GET: Routes
        public async Task<IActionResult> Index()
        {
            var vDSDBContext = _context.Routes.Include(r => r.Location);
            return View(await vDSDBContext.ToListAsync());
        }

        // GET: Routes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var route = await _context.Routes
                .Include(r => r.Location)
                .SingleOrDefaultAsync(m => m.RouteID == id);
            if (route == null)
            {
                return NotFound();
            }

            return View(route);
        }

        // GET: Routes/Create
        public IActionResult Create()
        {
            ViewData["LocationID"] = new SelectList(_context.Locations, "LocationID", "Name");
            return View();
        }

        // POST: Routes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RouteID,Rate,DriverRate,HelperRate,LocationID")] Route route)
        {
            if (ModelState.IsValid)
            {
                _context.Add(route);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["LocationID"] = new SelectList(_context.Locations, "LocationID", "Name", route.LocationID);
            return View(route);
        }

        // GET: Routes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var route = await _context.Routes.SingleOrDefaultAsync(m => m.RouteID == id);
            if (route == null)
            {
                return NotFound();
            }
            ViewData["LocationID"] = new SelectList(_context.Locations, "LocationID", "Name", route.LocationID);
            return View(route);
        }

        // POST: Routes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RouteID,Rate,DriverRate,HelperRate,LocationID")] Route route)
        {
            if (id != route.RouteID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(route);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RouteExists(route.RouteID))
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
            ViewData["LocationID"] = new SelectList(_context.Locations, "LocationID", "Name", route.LocationID);
            return View(route);
        }

        // GET: Routes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var route = await _context.Routes
                .Include(r => r.Location)
                .SingleOrDefaultAsync(m => m.RouteID == id);
            if (route == null)
            {
                return NotFound();
            }

            return View(route);
        }

        // POST: Routes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var route = await _context.Routes.SingleOrDefaultAsync(m => m.RouteID == id);
            _context.Routes.Remove(route);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool RouteExists(int id)
        {
            return _context.Routes.Any(e => e.RouteID == id);
        }
    }
}
