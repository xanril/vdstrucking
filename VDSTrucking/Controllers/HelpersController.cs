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
    public class HelpersController : Controller
    {
        private readonly VDSDBContext _context;

        public HelpersController(VDSDBContext context)
        {
            _context = context;    
        }

        // GET: Helpers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Helpers.ToListAsync());
        }

        // GET: Helpers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var helper = await _context.Helpers
                .SingleOrDefaultAsync(m => m.HelperID == id);
            if (helper == null)
            {
                return NotFound();
            }

            return View(helper);
        }

        // GET: Helpers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Helpers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HelperID,FirstName,LastName,MiddleName")] Helper helper)
        {
            if (ModelState.IsValid)
            {
                _context.Add(helper);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(helper);
        }

        // GET: Helpers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var helper = await _context.Helpers.SingleOrDefaultAsync(m => m.HelperID == id);
            if (helper == null)
            {
                return NotFound();
            }
            return View(helper);
        }

        // POST: Helpers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HelperID,FirstName,LastName,MiddleName")] Helper helper)
        {
            if (id != helper.HelperID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(helper);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HelperExists(helper.HelperID))
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
            return View(helper);
        }

        // GET: Helpers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var helper = await _context.Helpers
                .SingleOrDefaultAsync(m => m.HelperID == id);
            if (helper == null)
            {
                return NotFound();
            }

            return View(helper);
        }

        // POST: Helpers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var helper = await _context.Helpers.SingleOrDefaultAsync(m => m.HelperID == id);
            _context.Helpers.Remove(helper);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool HelperExists(int id)
        {
            return _context.Helpers.Any(e => e.HelperID == id);
        }
    }
}
