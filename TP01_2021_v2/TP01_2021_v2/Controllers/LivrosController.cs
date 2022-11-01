using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EW_2021_PAP1_DB_al73891;
using TP01_2021_v2.Models;
using Microsoft.AspNetCore.Http;
using System.Text.RegularExpressions;

namespace TP01_2021_v2.Controllers
{
    public class LivrosController : Controller
    {
        private readonly TP01Context _context;
        private readonly IHostEnvironment _he;

        public LivrosController(TP01Context context, IHostEnvironment e)
        {
            _context = context;
            _he = e;
        }

        // GET: Lista
        public async Task<IActionResult> Lista()
        {
            return View(await _context.Livro.ToListAsync());
        }

        // GET: Livros/Inserir
        public IActionResult Inserir()
        {
            return View();
        }

        // POST: Livros/Inserir
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Inserir(Livro livro, IFormCollection files)
        {
            if(ModelState.IsValid)
            {
                string destination = Path.Combine(
                        _he.ContentRootPath, "wwwroot\\Images\\", livro.ISBN);

                if (!Directory.Exists(destination))
                {
                    Directory.CreateDirectory(destination);
                }                

                foreach (var formFile in files.Files)
                {
                    string path = destination + "\\" + formFile.FileName;

                    FileStream fs = new FileStream(path, FileMode.Create);

                    formFile.CopyTo(fs);

                    if(formFile.Name == "Capa")
                        livro.Capa = formFile.FileName;
                    else if(formFile.Name == "Contracapa")
                        livro.Contracapa = formFile.FileName;

                    fs.Close();
                }

                _context.Add(livro);
                _context.SaveChanges();
                return RedirectToAction("Lista");
            }

            return View(livro);
        }

        // GET: Livros/Remover
        public async Task<IActionResult> Remover(int? id)
        {
            if (id == null || _context.Livro == null)
            {
                return NotFound();
            }

            var livro = await _context.Livro
                .FirstOrDefaultAsync(m => m.Id == id);
            if (livro == null)
            {
                return NotFound();
            }

            return View(livro);
        }

        // POST: Livros/Remover/5
        [HttpPost, ActionName("Remover")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RemoverConfirmed(int id)
        {
            if (_context.Livro == null)
            {
                return Problem("Entity set 'TP01Context.Livro'  is null.");
            }
            var livro = await _context.Livro.FindAsync(id);
            if (livro != null)
            {
                _context.Livro.Remove(livro);
                var path = _he.ContentRootPath + "wwwroot/Images/" + livro.ISBN;

                DirectoryInfo dirInfo = new DirectoryInfo(path);
                foreach(var file in dirInfo.GetFiles())
                {
                    System.IO.File.Delete(file.FullName);
                }
                Directory.Delete(path);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Lista));
        }

    }
}
