using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FinalProjectIDS309.Context;
using FinalProjectIDS309.Models;
using FinalProjectIDS309.ViewModels;

namespace FinalProjectIDS309.Controllers
{
    public class ItemsController : Controller
    {
        private readonly DBContextConfig _context;

        public ItemsController(DBContextConfig context)
        {
            _context = context;
        }

        // GET: Items
        public async Task<IActionResult> Index()
        {
            var dBContextConfig = _context.Items.Include(i => i.Category);
            return View(await dBContextConfig.ToListAsync());
        }

        // GET: Items
        public async Task<IActionResult> Index(string myUrl)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(i => i.Name == myUrl);

            var dBContextConfig = _context.Items.Include(i => i.Category).Where(i => i.IDCategory == category.ID);
            return View(await dBContextConfig.ToListAsync());
        }

        // GET: Items/Create
        public IActionResult Create()
        {
            ViewData["IDCategory"] = new SelectList(_context.Categories, "ID", "ID");
            return View();
        }

        // POST: Items/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Description,Quantity,IDCategory")] ItemModel itemModel)
        {
            if (ModelState.IsValid)
            {
                itemModel.ID = Guid.NewGuid();
                _context.Add(itemModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IDCategory"] = new SelectList(_context.Categories, "ID", "ID", itemModel.IDCategory);
            return View(itemModel);
        }

        // GET: Items/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemModel = await _context.Items.FindAsync(id);
            if (itemModel == null)
            {
                return NotFound();
            }
            ViewData["IDCategory"] = new SelectList(_context.Categories, "ID", "ID", itemModel.IDCategory);
            return View(itemModel);
        }

        // POST: Items/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ID,Name,Description,Quantity,IDCategory")] ItemModel itemModel)
        {
            if (id != itemModel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(itemModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemModelExists(itemModel.ID))
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
            ViewData["IDCategory"] = new SelectList(_context.Categories, "ID", "ID", itemModel.IDCategory);
            return View(itemModel);
        }

        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemModel = await _context.Items
                .FirstOrDefaultAsync(m => m.ID == id);
            if (itemModel == null)
            {
                return NotFound();
            }

            return View(itemModel);
        }

        // GET: Items/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemModel = await _context.Items
                .Include(i => i.Category)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (itemModel == null)
            {
                return NotFound();
            }

            return View(itemModel);
        }

        // POST: Items/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var itemModel = await _context.Items.FindAsync(id);
            _context.Items.Remove(itemModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ItemModelExists(Guid id)
        {
            return _context.Items.Any(e => e.ID == id);
        }

        public async Task<IActionResult> ByCategory(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var Cartegory = await _context.Categories.FindAsync(id);
            var ItemsQuery = _context.Items.Where(i => i.IDCategory == id);

            CategoryItemsViewModel model = new CategoryItemsViewModel()
            {
                CategoryName = Cartegory.Name,
                Items = await ItemsQuery.ToListAsync()
            };

            return View(model);
        }
    }
}
