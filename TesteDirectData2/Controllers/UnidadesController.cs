using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TesteDirectData.Context;
using TesteDirectData.Models;

namespace TesteDirectData2.Controllers
{
    public class UnidadesController : Controller
    {
        private readonly DataContext _context;

        public UnidadesController(DataContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> ExibirUnidade()
        {
            return View("~/Views/Unidades/IndexAjaxUnidades.cshtml");

        }
        [HttpGet]
        public async Task<IActionResult> getUnidades()
        {
            if (_context.Unidades != null)
            {
                return Json(await _context.Unidades.ToListAsync());
            }
            return Problem("Entity set 'DataContext.Unidades'  is null.");
        }

        [HttpPost]
        public async Task<IActionResult> novaUnidade(Unidade unidade)
        {
            if (ModelState.IsValid)
            {
                _context.Add(unidade);
                await _context.SaveChangesAsync();
                return Json(unidade);
            }
            return Json(ModelState);
        }

        [HttpGet]
        public async Task<IActionResult> pegarUnidadeID(int unidadeId)
        {
            Unidade unidade = await _context.Unidades.FindAsync(unidadeId);
            if (unidade != null)
                return Json(unidade);
            return Json(new { mensagem = "Unidade não encontrada" });
        }

        [HttpPost]
        public async Task<IActionResult> atualizarUnidade(Unidade unidade)
        {
            if (ModelState.IsValid)
            {
                _context.Unidades.Update(unidade);
                await _context.SaveChangesAsync();
                return Json(unidade);
            }
            return Json(ModelState);
        }
        [HttpPost]
        public async Task<IActionResult> excluirUnidade(int unidadeId)
        {
            Unidade unidade = await _context.Unidades.FindAsync(unidadeId);
            if (unidade != null)
            {
                _context.Unidades.Remove(unidade);
                await _context.SaveChangesAsync();
                return Json("Removido com sucesso");
            }
            return Json(new { mensagem = "Unidade não encontrada" });
        }


        //Gerado pela Entity

        // GET: Unidades
        public async Task<IActionResult> Index()
        {
            return _context.Unidades != null ?
                        View(await _context.Unidades.ToListAsync()) :
                        Problem("Entity set 'DataContext.Unidades'  is null.");
        }

        // GET: Unidades/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Unidades == null)
            {
                return NotFound();
            }

            var unidade = await _context.Unidades
                .FirstOrDefaultAsync(m => m.ID == id);
            if (unidade == null)
            {
                return NotFound();
            }

            return View(unidade);
        }

        // GET: Unidades/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Unidades/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Nome,Localidade,Contato")] Unidade unidade)
        {
            if (ModelState.IsValid)
            {
                _context.Add(unidade);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(unidade);
        }

        // GET: Unidades/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Unidades == null)
            {
                return NotFound();
            }

            var unidade = await _context.Unidades.FindAsync(id);
            if (unidade == null)
            {
                return NotFound();
            }
            return View(unidade);
        }

        // POST: Unidades/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Nome,Localidade,Contato")] Unidade unidade)
        {
            if (id != unidade.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(unidade);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UnidadeExists(unidade.ID))
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
            return View(unidade);
        }

        // GET: Unidades/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Unidades == null)
            {
                return NotFound();
            }

            var unidade = await _context.Unidades
                .FirstOrDefaultAsync(m => m.ID == id);
            if (unidade == null)
            {
                return NotFound();
            }

            return View(unidade);
        }

        // POST: Unidades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Unidades == null)
            {
                return Problem("Entity set 'DataContext.Unidades'  is null.");
            }
            var unidade = await _context.Unidades.FindAsync(id);
            if (unidade != null)
            {
                _context.Unidades.Remove(unidade);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UnidadeExists(int id)
        {
            return (_context.Unidades?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
