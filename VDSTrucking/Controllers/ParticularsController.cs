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
    public class ParticularsController : Controller
    {
        private readonly VDSDBContext _context;

        public ParticularsController(VDSDBContext context)
        {
            _context = context;    
        }

        // GET: Particulars
        public async Task<IActionResult> Index()
        {
            var vDSDBContext = _context.Particulars.Include(p => p.ParticularItem);
            return View(await vDSDBContext.ToListAsync());
        }

        // GET: Particulars/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var particular = await _context.Particulars
                .Include(p => p.ParticularItem)
                .SingleOrDefaultAsync(m => m.ParticularID == id);
            if (particular == null)
            {
                return NotFound();
            }

            return View(particular);
        }

        // GET: Particulars/Create
        public IActionResult Create()
        {
            ViewData["ParticularItemID"] = new SelectList(_context.ParticularItems, "ParticularItemID", "Name");
            return View();
        }

        // POST: Particulars/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ParticularID,Cost,ParticularItemID")] Particular particular)
        {
            if (ModelState.IsValid)
            {
                _context.Add(particular);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["ParticularItemID"] = new SelectList(_context.ParticularItems, "ParticularItemID", "Name", particular.ParticularItemID);
            return View(particular);
        }

        // GET: Particulars/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var particular = await _context.Particulars.SingleOrDefaultAsync(m => m.ParticularID == id);
            if (particular == null)
            {
                return NotFound();
            }
            ViewData["ParticularItemID"] = new SelectList(_context.ParticularItems, "ParticularItemID", "Name", particular.ParticularItemID);
            return View(particular);
        }

        // POST: Particulars/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ParticularID,Cost,ParticularItemID")] Particular particular)
        {
            if (id != particular.ParticularID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(particular);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ParticularExists(particular.ParticularID))
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
            ViewData["ParticularItemID"] = new SelectList(_context.ParticularItems, "ParticularItemID", "Name", particular.ParticularItemID);
            return View(particular);
        }

        // GET: Particulars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var particular = await _context.Particulars
                .Include(p => p.ParticularItem)
                .SingleOrDefaultAsync(m => m.ParticularID == id);
            if (particular == null)
            {
                return NotFound();
            }

            return View(particular);
        }

        // POST: Particulars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var particular = await _context.Particulars.SingleOrDefaultAsync(m => m.ParticularID == id);
            _context.Particulars.Remove(particular);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ParticularExists(int id)
        {
            return _context.Particulars.Any(e => e.ParticularID == id);
        }
    }
}
