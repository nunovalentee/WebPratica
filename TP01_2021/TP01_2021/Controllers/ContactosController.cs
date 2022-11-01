using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DB_al73891;
using TP01_2021.Models;

namespace TP01_2021.Controllers
{
    public class ContactosController : Controller
    {
        private readonly TP01Context _context;

        public ContactosController(TP01Context context)
        {
            _context = context;
        }

        // GET: Contactos
        public async Task<IActionResult> Lista()
        {
            return View(await _context.Contacto.ToListAsync());
        }

        public async Task<IActionResult> Lista2()
        {
            return View(await _context.Contacto.Where(x => x.Amigo == true).ToListAsync());
        }

        // GET: Contactos/Alterar/5
        public async Task<IActionResult> Alterar(int? id)
        {
            if (id == null || _context.Contacto == null)
            {
                return NotFound();
            }

            var contacto = await _context.Contacto.FindAsync(id);
            if (contacto == null)
            {
                return NotFound();
            }
            return View(contacto);
        }

        // POST: Contactos/Alterar/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Alterar(int id, [Bind("Id,Email,NickName,Nome,Amigo")] Contacto contacto)
        {
            if (id != contacto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contacto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContactoExists(contacto.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                
                TempData["Success"] = contacto.NickName + " saved successfully!"; // TempData just stays in memory during one request
                return RedirectToAction(nameof(Lista));
            }
            return View(contacto);
        }

        private bool ContactoExists(int id)
        {
          return _context.Contacto.Any(e => e.Id == id);
        }
    }
}
