using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Security.Principal;
using TP01_2019.Data;
using TP01_2019.Models;

namespace TP01_2019.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly TP01_2019Context _context;

        public HomeController(ILogger<HomeController> logger, TP01_2019Context context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var tp01_2019context = _context.Piloto.Include(p => p.Carro);
            return View(tp01_2019context.OrderByDescending(x => x.Pontos).ToList());
        }

        public async Task<IActionResult> Adiciona(int? id)
        {
            if(id == null || _context.Piloto == null)
            {
                return NotFound();
            }

            var piloto = _context.Piloto.FirstOrDefault(x => x.Id == id);
            if(piloto == null)
            {
                return NotFound();
            }

            piloto.Pontos = piloto.Pontos + 1;

            _context.Update(piloto);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        // GET: Carros/Create
        public IActionResult Create()
        {
            ViewData["CarroId"] = new SelectList(_context.Carro, "Id", "Equipa");
            return View();
        }

        // POST: Carros/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Piloto piloto)
        {
            if(piloto.Pontos == null)
            {
                piloto.Pontos = 0;
            }


            if (ModelState.IsValid)
            {
                _context.Add(piloto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CarroId"] = new SelectList(_context.Carro, "Id", "Equipa", piloto.CarroId);
            return View(piloto);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}