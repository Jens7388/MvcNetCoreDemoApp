using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using DataAccess;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcNetCore.Models;
using MvcNetCore.Models.Context;

namespace MvcNetCore.Controllers
{
    public class SupplierController : Controller
    {
        private readonly SupplierRepository _repo;

        public SupplierController(SupplierRepository repo)
        {
            _repo = repo;
        }

        // GET: Supplier
        public async Task<IActionResult> Index()
        {
            IEnumerable<Supplier> suppliers = await _repo.GetAllAsync();

            return View(suppliers);
        }

        // GET: Supplier/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if(id == 0)
            {
                return NotFound();
            }

            Supplier supplier = await _repo.GetByIdAsync(id);

            if(supplier == null)
            {
                return NotFound();
            }
            return View(supplier);
        }

        // GET: Supplier/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Supplier/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SupplierId,CompanyName,ContactName,ContactTitle,Address,City,Region,PostalCode,Country,Phone,Fax,HomePage")] Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                await _repo.AddAsync(supplier);
                return RedirectToAction(nameof(Index));
            }
            return View(supplier);
        }

        // GET: Supplier/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            Supplier supplier = await _repo.GetByIdAsync(id);
            if (supplier == null)
            {
                return NotFound();
            }
           // IEnumerable<Product> products = await new ProductRepository().GetAllAsync();

           // ViewData["ProductId"] = new SelectList(products, "ProductId", "ProductName", supplier.Products);
            return View(supplier);
        }

        // POST: Supplier/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SupplierId,CompanyName,ContactName,ContactTitle,Address,City,Region,PostalCode,Country,Phone,Fax,HomePage")] Supplier supplier)
        {
            if (id != supplier.SupplierId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _repo.UpdateAsync(supplier);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await SupplierExistsAsync(supplier.SupplierId))
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
            return View(supplier);
        }

        // GET: Supplier/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            Supplier supplier = await _repo.GetByIdAsync(id);
            if (supplier == null)
            {
                return NotFound();
            }

            return View(supplier);
        }

        // POST: Supplier/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            Supplier supplier = await _repo.GetByIdAsync(id);

            await _repo.DeleteAsync(supplier);

            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> SupplierExistsAsync(int id)
        {
            Supplier result = await _repo.GetByIdAsync(id);

            return (result != null);
        }
    }
}