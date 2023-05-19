﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MotorAsinBasketRobot.DataAccess.Concrete.EntityFramework.Context;
using MotorAsinBasketRobot.Entities.Identity;

namespace MotorAsinBasketProjectClient.UI.Controllers
{
    public class AppRolesController : Controller
    {
        private readonly AppDbContext _context;

        public AppRolesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: AppRoles
        public async Task<IActionResult> Index()
        {
              return _context.AppRoles != null ? 
                          View(await _context.AppRoles.ToListAsync()) :
                          Problem("Entity set 'AppDbContext.AppRoles'  is null.");
        }

        // GET: AppRoles/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.AppRoles == null)
            {
                return NotFound();
            }

            var appRole = await _context.AppRoles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (appRole == null)
            {
                return NotFound();
            }

            return View(appRole);
        }

        // GET: AppRoles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AppRoles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,NormalizedName,ConcurrencyStamp")] AppRole appRole)
        {
            if (ModelState.IsValid)
            {
                _context.Add(appRole);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(appRole);
        }

        // GET: AppRoles/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.AppRoles == null)
            {
                return NotFound();
            }

            var appRole = await _context.AppRoles.FindAsync(id);
            if (appRole == null)
            {
                return NotFound();
            }
            return View(appRole);
        }

        // POST: AppRoles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Name,NormalizedName,ConcurrencyStamp")] AppRole appRole)
        {
            if (id != appRole.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(appRole);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AppRoleExists(appRole.Id))
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
            return View(appRole);
        }

        // GET: AppRoles/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.AppRoles == null)
            {
                return NotFound();
            }

            var appRole = await _context.AppRoles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (appRole == null)
            {
                return NotFound();
            }

            return View(appRole);
        }

        // POST: AppRoles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.AppRoles == null)
            {
                return Problem("Entity set 'AppDbContext.AppRoles'  is null.");
            }
            var appRole = await _context.AppRoles.FindAsync(id);
            if (appRole != null)
            {
                _context.AppRoles.Remove(appRole);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AppRoleExists(string id)
        {
          return (_context.AppRoles?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
