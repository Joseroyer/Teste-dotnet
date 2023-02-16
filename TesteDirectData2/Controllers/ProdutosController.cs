using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TesteDirectData.Context;
using TesteDirectData.Models;

namespace TesteDirectData2.Controllers
{
    public class ProdutosController : Controller
    {
        private readonly DataContext _context;

        public ProdutosController(DataContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> ExibirProdutos()
        {
            return View("~/Views/Produtos/IndexAjaxProdutos.cshtml");

        }

        public async Task<IActionResult> getProdutos()
        {
            if (_context.Produtos != null)
            {
                var dataContext = _context.Produtos.Include(p => p.Categorias).Include(p => p.Unidade);
                return Json(await dataContext.ToListAsync());
            }
            return Problem("Entity set 'DataContext.Produtos'  is null.");
        }
        [HttpPost]
        public async Task<IActionResult> novoProduto(Produto produto)
        {
            if (ModelState.IsValid)
            {
                //var Unidade = _context.Unidades.Find(produto.UnidadeID);
                //produto.Unidade = Unidade;
                //var Categoria = _context.Categorias.Find(produto.CategoriaID);
                //produto.Categorias = Categoria;
                _context.Add(produto);
                await _context.SaveChangesAsync();
                return Json(produto);
            }
            return Json(ModelState);
        }

        [HttpGet]
        public async Task<IActionResult> pegarProdutoID(int produtoId)
        {
            Produto produto = await _context.Produtos.FindAsync(produtoId);
            if (produto != null)
                return Json(produto);
            return Json(new { mensagem = "Produto não encontrado" });
        }

        [HttpPost]
        public async Task<IActionResult> atualizarProduto(Produto produto)
        {
            if (ModelState.IsValid)
            {
                _context.Produtos.Update(produto);
                await _context.SaveChangesAsync();
                return Json(produto);
            }

            return Json(ModelState);
        }
        [HttpPost]
        public async Task<IActionResult> excluirProduto(int produtoId)
        {
            Produto produto = await _context.Produtos.FindAsync(produtoId);
            if (produto != null)
            {
                _context.Produtos.Remove(produto);
                await _context.SaveChangesAsync();
                return Json("Removido com sucesso");
            }
            return Json(new { mensagem = "Produto não encontrado" });
        }

        //Gerado pelo Entity
        // GET: Produtos
        public async Task<IActionResult> Index()
        {
            var dataContext = _context.Produtos.Include(p => p.Categorias).Include(p => p.Unidade);
            return View(await dataContext.ToListAsync());
        }

        // GET: Produtos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Produtos == null)
            {
                return NotFound();
            }

            var produto = await _context.Produtos
                .Include(p => p.Categorias)
                .Include(p => p.Unidade)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        // GET: Produtos/Create
        public IActionResult Create()
        {
            ViewData["CategoriaID"] = new SelectList(_context.Categorias, "ID", "Nome");
            ViewData["UnidadeID"] = new SelectList(_context.Unidades, "ID", "Contato");
            return View();
        }

        // POST: Produtos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Nome,PrecoVenda,Estoque,Ativo,UnidadeID,CategoriaID")] Produto produto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(produto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoriaID"] = new SelectList(_context.Categorias, "ID", "Nome", produto.CategoriaID);
            ViewData["UnidadeID"] = new SelectList(_context.Unidades, "ID", "Contato", produto.UnidadeID);
            return View(produto);
        }

        // GET: Produtos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Produtos == null)
            {
                return NotFound();
            }

            var produto = await _context.Produtos.FindAsync(id);
            if (produto == null)
            {
                return NotFound();
            }
            ViewData["CategoriaID"] = new SelectList(_context.Categorias, "ID", "Nome", produto.CategoriaID);
            ViewData["UnidadeID"] = new SelectList(_context.Unidades, "ID", "Contato", produto.UnidadeID);
            return View(produto);
        }

        // POST: Produtos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Nome,PrecoVenda,Estoque,Ativo,UnidadeID,CategoriaID")] Produto produto)
        {
            if (id != produto.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(produto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProdutoExists(produto.ID))
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
            ViewData["CategoriaID"] = new SelectList(_context.Categorias, "ID", "Nome", produto.CategoriaID);
            ViewData["UnidadeID"] = new SelectList(_context.Unidades, "ID", "Contato", produto.UnidadeID);
            return View(produto);
        }

        // GET: Produtos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Produtos == null)
            {
                return NotFound();
            }

            var produto = await _context.Produtos
                .Include(p => p.Categorias)
                .Include(p => p.Unidade)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        // POST: Produtos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Produtos == null)
            {
                return Problem("Entity set 'DataContext.Produtos'  is null.");
            }
            var produto = await _context.Produtos.FindAsync(id);
            if (produto != null)
            {
                _context.Produtos.Remove(produto);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProdutoExists(int id)
        {
            return (_context.Produtos?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
