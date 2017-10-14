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
    public class HelperListsController : Controller
    {
        private readonly VDSDBContext _context;

        public HelperListsController(VDSDBContext context)
        {
            _context = context;    
        }

        // GET: HelperLists
        public async Task<IActionResult> Index()
        {
            var vDSDBContext = _context.HelperList.Include(h => h.Trip);
            return View(await vDSDBContext.ToListAsync());
        }

        // GET: HelperLists/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var helperList = await _context.HelperList
                .Include(h => h.Trip)
                .SingleOrDefaultAsync(m => m.HelperListID == id);
            if (helperList == null)
            {
                return NotFound();
            }

            return View(helperList);
        }

        // GET: HelperLists/Create
        public IActionResult Create()
        {
            ViewData["TripID"] = new SelectList(_context.Trips, "TripID", "TripID");
            return View();
        }

        // POST: HelperLists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HelperListID,TripID")] HelperList helperList)
        {
            if (ModelState.IsValid)
            {
                _context.Add(helperList);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["TripID"] = new SelectList(_context.Trips, "TripID", "TripID", helperList.TripID);
            return View(helperList);
        }

        // GET: HelperLists/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var helperList = await _context.HelperList.SingleOrDefaultAsync(m => m.HelperListID == id);
            if (helperList == null)
            {
                return NotFound();
            }
            ViewData["TripID"] = new SelectList(_context.Trips, "TripID", "TripID", helperList.TripID);
            return View(helperList);
        }

        // POST: HelperLists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HelperListID,TripID")] HelperList helperList)
        {
            if (id != helperList.HelperListID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(helperList);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HelperListExists(helperList.HelperListID))
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
            ViewData["TripID"] = new SelectList(_context.Trips, "TripID", "TripID", helperList.TripID);
            return View(helperList);
        }

        // GET: HelperLists/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var helperList = await _context.HelperList
                .Include(h => h.Trip)
                .SingleOrDefaultAsync(m => m.HelperListID == id);
            if (helperList == null)
            {
                return NotFound();
            }

            return View(helperList);
        }

        // POST: HelperLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var helperList = await _context.HelperList.SingleOrDefaultAsync(m => m.HelperListID == id);
            _context.HelperList.Remove(helperList);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool HelperListExists(int id)
        {
            return _context.HelperList.Any(e => e.HelperListID == id);
        }
    }
}
