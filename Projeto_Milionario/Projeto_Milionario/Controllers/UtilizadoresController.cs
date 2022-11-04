using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Projeto_Milionario.Data;
using Projeto_Milionario.Models;

namespace Projeto_Milionario.Controllers
{
    public class UtilizadoresController : Controller
    {
        private readonly Projeto_MilionarioContext _context;
        private readonly IHostEnvironment _he;

        public UtilizadoresController(Projeto_MilionarioContext context, IHostEnvironment e)
        {
            _context = context;
            _he = e;
        }

        // GET: Utilizadores
        public async Task<IActionResult> Index()
        {
            var projeto_MilionarioContext = _context.Utilizador.Include(u => u.Curso);
            return View(await projeto_MilionarioContext.ToListAsync());
        }

        // GET: Utilizadores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Utilizador == null)
            {
                return NotFound();
            }

            var utilizador = await _context.Utilizador
                .Include(u => u.Curso)
                .FirstOrDefaultAsync(m => m.Numero == id);
            if (utilizador == null)
            {
                return NotFound();
            }

            return View(utilizador);
        }

        // GET: Utilizadores/Create
        public IActionResult Create()
        {
            ViewData["CursoId"] = new SelectList(_context.Curso.Where(x => x.State == true), "Id", "Nome");
            return View();
        }

        // POST: Utilizadores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Utilizador utilizador, IFormFile Foto)
        {
            if (ModelState.IsValid)
            {
                if(utilizador.Foto != null)
                {
                    var destination = Path.Combine(_he.ContentRootPath, "wwwroot/Fotos/", Path.GetFileName(utilizador.Numero.ToString()) + ".jpg");

                    FileStream fs = new FileStream(destination, FileMode.Create);

                    await Foto.CopyToAsync(fs);

                    fs.Close();

                    utilizador.Foto = utilizador.Numero.ToString() + ".jpg";
                }

                _context.Add(utilizador);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CursoId"] = new SelectList(_context.Curso.Where(x => x.State == true), "Id", "Nome", utilizador.CursoId);
            return View(utilizador);
        }

        // GET: Utilizadores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Utilizador == null)
            {
                return NotFound();
            }

            var utilizador = await _context.Utilizador.FindAsync(id);
            if (utilizador == null)
            {
                return NotFound();
            }
            ViewData["CursoId"] = new SelectList(_context.Curso, "Id", "Nome", utilizador.CursoId);
            return View(utilizador);
        }

        // POST: Utilizadores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Numero,Nome,Email,Foto,Cargo,CursoId")] Utilizador utilizador, IFormFile Foto)
        {
            if (id != utilizador.Numero)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (Foto != null)
                    {
                        var destination = Path.Combine(_he.ContentRootPath, "wwwroot/Fotos/", Path.GetFileName(utilizador.Numero.ToString()));

                        FileStream fs = new FileStream(destination, FileMode.Create);

                        await Foto.CopyToAsync(fs);

                        fs.Close();
                    }
                    _context.Update(utilizador);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UtilizadorExists(utilizador.Numero))
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
            ViewData["CursoId"] = new SelectList(_context.Curso, "Id", "Nome", utilizador.CursoId);
            return View(utilizador);
        }

        // GET: Utilizadores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Utilizador == null)
            {
                return NotFound();
            }

            var utilizador = await _context.Utilizador
                .Include(u => u.Curso)
                .FirstOrDefaultAsync(m => m.Numero == id);
            if (utilizador == null)
            {
                return NotFound();
            }

            return View(utilizador);
        }

        // POST: Utilizadores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Utilizador == null)
            {
                return Problem("Entity set 'Projeto_MilionarioContext.Utilizador'  is null.");
            }
            var utilizador = await _context.Utilizador.FindAsync(id);
            if (utilizador != null)
            {
                _context.Utilizador.Remove(utilizador);
                
                if(utilizador.Foto != null)
                {
                    var path = _he.ContentRootPath + "wwwroot/Fotos";

                    DirectoryInfo dirInfo = new DirectoryInfo(path);
                    foreach (var file in dirInfo.GetFiles())
                    {
                        if(file.Name.Equals(utilizador.Foto))
                            System.IO.File.Delete(file.FullName);
                    }
                } 
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UtilizadorExists(int id)
        {
          return _context.Utilizador.Any(e => e.Numero == id);
        }
    }
}
