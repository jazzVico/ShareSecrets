using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShareSecrets.Models;

namespace ShareSecrets.Controllers
{
    public class ShareSecretsController : Controller
    {
        private readonly ShareSecretsContext _context;

        public ShareSecretsController(ShareSecretsContext context)
        {
            _context = context;
        }

        // GET: ShareSecrets
        public async Task<IActionResult> Index()
        {
            return View(await _context.Secret.ToListAsync());
        }

        // GET: ShareSecrets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var secret = await _context.Secret
                .FirstOrDefaultAsync(m => m.ID == id);
            if (secret == null)
            {
                return NotFound();
            }

            return View(secret);
        }

        // GET: ShareSecrets/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ShareSecrets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,NikName,Age,Gender,Text")] Secret secret)
        {
            if (ModelState.IsValid)
            {
                _context.Add(secret);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(secret);
        }

        // GET: ShareSecrets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var secret = await _context.Secret.FindAsync(id);
            if (secret == null)
            {
                return NotFound();
            }
            return View(secret);
        }

        // POST: ShareSecrets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,NikName,Age,Gender,Text")] Secret secret)
        {
            if (id != secret.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(secret);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SecretExists(secret.ID))
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
            return View(secret);
        }

        // GET: ShareSecrets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var secret = await _context.Secret
                .FirstOrDefaultAsync(m => m.ID == id);
            if (secret == null)
            {
                return NotFound();
            }

            return View(secret);
        }

        // POST: ShareSecrets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var secret = await _context.Secret.FindAsync(id);
            _context.Secret.Remove(secret);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SecretExists(int id)
        {
            return _context.Secret.Any(e => e.ID == id);
        }
    }
}
