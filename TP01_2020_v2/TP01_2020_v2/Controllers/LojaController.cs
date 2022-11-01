using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EW_PAP1_DB_v2;
using TP01_2020_v2.Models;

namespace TP01_2020_v2.Controllers
{
    public class LojaController : Controller
    {
        private readonly TP01Context _context;
        private readonly IHostEnvironment _he;

        public LojaController(TP01Context context, IHostEnvironment e)
        {
            _context = context;
            _he = e;
        }

        // GET: Loja
        public async Task<IActionResult> Index()
        {
              return View(await _context.Carro.OrderByDescending(x => x.Ano).ToListAsync());
        }

        public async Task<IActionResult> Inserir()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Inserir(Carro carro, IFormFile Foto)
        {
            carro.Foto = Foto.FileName;

            if (ModelState.IsValid)
            {
                var destination = Path.Combine(_he.ContentRootPath, "wwwroot/Fotos", Path.GetFileName(Foto.FileName));

                FileStream fs = new FileStream(destination, FileMode.Create);

                await Foto.CopyToAsync(fs);

                fs.Close();

                _context.Add(carro);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(carro);
        }

        public async Task<IActionResult> Comprar(int? id)
        {
            if(id == null || _context.Carro == null)
            {
                return NotFound();
            }

            var carro = await _context.Carro.FirstOrDefaultAsync(m => m.Id == id);

            if(carro == null)
            {
                return NotFound();
            }

            carro.Vendido = true;
            _context.Update(carro);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}
