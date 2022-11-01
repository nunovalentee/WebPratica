using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EW_PAP1_DB_al73891;
using TP01_2020.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace TP01_2020.Controllers
{
    public class UtilizadoresController : Controller
    {
        private readonly TP01Context _context;

        public UtilizadoresController(TP01Context context)
        {
            _context = context;
        }

        // GET: Utilizadores
        public async Task<IActionResult> Index()
        {
            return View(await _context.Utilizador.ToListAsync());
        }

        public async Task<IActionResult> Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(string username, string password, Utilizador user)
        {
            if (UtilizadorExists(username))
            {
                var validation = _context.Utilizador.Where(x => x.Username.Equals(username) && x.Password.Equals(password)).FirstOrDefault();

                if (validation != null)
                    return RedirectToAction(nameof(Index));
            }

            //ModelState.AddModelError("Username", "Credenciais inválidas! Tente de novo");

            return View(user);
        }

        public async Task<IActionResult> Registar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Registar(Utilizador user)
        {
            
            if (ModelState.IsValid)
            {
                if (UtilizadorExists(user.Username))
                {
                    ModelState.AddModelError("Username", "Username já existe. Escolha um novo.");
                }
                else
                {
                    _context.Add(user);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Login");
                }
            }

            return View(user);
        }


        public async Task<IActionResult> Editar(int? id)
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
            return View(utilizador);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, Utilizador user)
        {
            if (id != user.Id)
            {
                return NotFound();
            }
            
            if (ModelState.IsValid)
            {
                try
                {
                    if (UtilizadorExists(user.Username))
                    {
                        ModelState.AddModelError("Username", "Username já existe. Escolha um novo.");
                    }
                    else
                    {
                        _context.Update(user);
                        await _context.SaveChangesAsync();
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UtilizadorExists(user.Username))
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
            return View(user);
        }

        private bool UtilizadorExists(string username)
        {
          return _context.Utilizador.Any(e => e.Username == username);
        }
    }
}
