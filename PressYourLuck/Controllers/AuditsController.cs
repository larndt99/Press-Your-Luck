using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PressYourLuck.Models;

namespace PressYourLuck.Controllers
{
    public class AuditsController : Controller
    {
        private readonly AuditContext _context;

        public AuditsController(AuditContext context)
        {
            _context = context;
        }

        // GET: Audits
        public async Task<IActionResult> Index()
        {
            IQueryable<Audit> auditList = _context.Audit.Include(m => m.Type);
            auditList = auditList.OrderByDescending(x => x.CreatedDate);
            return View(auditList.ToList());
            //var auditContext = _context.Audit.Include(a => a.Type);
            //return View(await auditContext.ToListAsync());
            //return View(await _context.Audit.OrderByDescending(x => x.CreatedDate).ToListAsync());
        }

        // GET: Audits/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var audit = await _context.Audit
                .Include(a => a.Type)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (audit == null)
            {
                return NotFound();
            }

            return View(audit);
        }

        // GET: Audits/Create
        public IActionResult Create()
        {
            ViewData["TypeId"] = new SelectList(_context.AuditType, "AuditTypeId", "AuditTypeId");
            return View();
        }

        // POST: Audits/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PlayerName,CreatedDate,Amount,TypeId")] Audit audit)
        {
            if (ModelState.IsValid)
            {
                _context.Add(audit);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TypeId"] = new SelectList(_context.AuditType, "AuditTypeId", "AuditTypeId", audit.TypeId);
            return View(audit);
        }

        // GET: Audits/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var audit = await _context.Audit.FindAsync(id);
            if (audit == null)
            {
                return NotFound();
            }
            ViewData["TypeId"] = new SelectList(_context.AuditType, "AuditTypeId", "AuditTypeId", audit.TypeId);
            return View(audit);
        }

        // POST: Audits/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PlayerName,CreatedDate,Amount,TypeId")] Audit audit)
        {
            if (id != audit.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(audit);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AuditExists(audit.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["TypeId"] = new SelectList(_context.AuditType, "AuditTypeId", "AuditTypeId", audit.TypeId);
            return View(audit);
        }

        // GET: Audits/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var audit = await _context.Audit
                .Include(a => a.Type)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (audit == null)
            {
                return NotFound();
            }

            return View(audit);
        }

        // POST: Audits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var audit = await _context.Audit.FindAsync(id);
            _context.Audit.Remove(audit);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AuditExists(int id)
        {
            return _context.Audit.Any(e => e.Id == id);
        }
    }
}
