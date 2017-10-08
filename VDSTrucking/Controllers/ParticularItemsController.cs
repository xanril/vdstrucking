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
    public class ParticularItemsController : Controller
    {
        private readonly VDSDBContext _context;

        public ParticularItemsController(VDSDBContext context)
        {
            _context = context;    
        }

        // GET: ParticularItems
        public async Task<IActionResult> Index()
        {
            return View(await _context.ParticularItems.ToListAsync());
        }

        // GET: ParticularItems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var particularItem = await _context.ParticularItems
                .SingleOrDefaultAsync(m => m.ParticularItemID == id);
            if (particularItem == null)
            {
                return NotFound();
            }

            return View(particularItem);
        }

        // GET: ParticularItems/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ParticularItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ParticularItemID,Name")] ParticularItem particularItem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(particularItem);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(particularItem);
        }

        // GET: ParticularItems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var particularItem = await _context.ParticularItems.SingleOrDefaultAsync(m => m.ParticularItemID == id);
            if (particularItem == null)
            {
                return NotFound();
            }
            return View(particularItem);
        }

        // POST: ParticularItems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ParticularItemID,Name")] ParticularItem particularItem)
        {
            if (id != particularItem.ParticularItemID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(particularItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ParticularItemExists(particularItem.ParticularItemID))
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
            return View(particularItem);
        }

        // GET: ParticularItems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var particularItem = await _context.ParticularItems
                .SingleOrDefaultAsync(m => m.ParticularItemID == id);
            if (particularItem == null)
            {
                return NotFound();
            }

            return View(particularItem);
        }

        // POST: ParticularItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var particularItem = await _context.ParticularItems.SingleOrDefaultAsync(m => m.ParticularItemID == id);
            _context.ParticularItems.Remove(particularItem);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ParticularItemExists(int id)
        {
            return _context.ParticularItems.Any(e => e.ParticularItemID == id);
        }
    }
}
