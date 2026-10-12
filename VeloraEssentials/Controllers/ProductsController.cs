using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VeloraEssentials.Data;
using VeloraEssentials.Models;

namespace VeloraEssentials.Controllers
{
    public class ProductsController : Controller
    {
        private readonly AppDbContext _db;
        public ProductsController(AppDbContext db) => _db = db;

        // List with optional search and category filter
        public async Task<IActionResult> Index(string? search, string? category)
        {
            var query = _db.Products.AsQueryable();

            if (!string.IsNullOrWhiteSpace(search))
                query = query.Where(p => p.Name.Contains(search));
            if (!string.IsNullOrWhiteSpace(category))
                query = query.Where(p => p.Category == category);

            ViewBag.Search = search;
            ViewBag.Category = category;
            ViewBag.Categories = await _db.Products.Select(p => p.Category).Distinct().OrderBy(c => c).ToListAsync();

            return View(await query.OrderBy(p => p.Name).ToListAsync());
        }

        public IActionResult Create() => View(new Product());

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product)
        {
            if (!ModelState.IsValid) return View(product);

            _db.Products.Add(product);
            await _db.SaveChangesAsync();
            TempData["Message"] = "Product added successfully.";
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var product = await _db.Products.FindAsync(id);
            if (product == null) return NotFound();
            return View(product);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Product product)
        {
            if (id != product.Id) return NotFound();
            if (!ModelState.IsValid) return View(product);

            _db.Update(product);
            await _db.SaveChangesAsync();
            TempData["Message"] = "Product updated successfully.";
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var product = await _db.Products.FindAsync(id);
            if (product == null) return NotFound();
            return View(product);
        }

        [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _db.Products.FindAsync(id);
            if (product != null)
            {
                _db.Products.Remove(product);
                await _db.SaveChangesAsync();
                TempData["Message"] = "Product deleted.";
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
