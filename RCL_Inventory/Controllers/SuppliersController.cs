using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RCL_Inventory.Models;
using RCL_Inventory.Models.ViewModels.SupplierViewModel;

namespace RCL_Inventory.Controllers
{

    public class SuppliersController : Controller
    {
        private readonly InventoryContext _context;

        public SuppliersController(InventoryContext context)
        {
            _context = context;
        }

        // GET: Suppliers
        public async Task<IActionResult> Index()
        {
            var inventoryContext = _context.Suppliers.Include(s => s.Address);
            return View(await inventoryContext.ToListAsync());
        }

        // GET: Suppliers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supplier = await _context.Suppliers
                .Include(s => s.Address)
                .FirstOrDefaultAsync(m => m.SupplierId == id);
            if (supplier == null)
            {
                return NotFound();
            }

            return View(supplier);
        }

        // GET: Suppliers/Create
        public IActionResult Create()
        {
            var suppliers = _context.Suppliers.ToList();
            var addresses = _context.Addresses.ToList();

            SupplierViewModel svm = new SupplierViewModel(){
            SuppliersList = suppliers,
            AddressesList = addresses
            };


            ViewData["AddressId"] = new SelectList(_context.Addresses, "AddressId", "City");
            return View(svm);
        }

        // POST: Suppliers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SupplierId,Name,Telephone,AccountNumber,AddressId")] Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                _context.Add(supplier);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AddressId"] = new SelectList(_context.Addresses, "AddressId", "City", supplier.AddressId);
            return View(supplier);
        }

        // GET: Suppliers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var suppliers = _context.Suppliers.ToList();
            var addresses = _context.Addresses.ToList();


            var supplier = await _context.Suppliers.FindAsync(id);
            int supplierId = supplier.SupplierId;

            var svm = new SupplierViewModel()
            {
                AddressesList = addresses,
                SuppliersList = suppliers,
                SupplierId = supplierId

            };


            if (svm == null)
            {
                return NotFound();
            }
            ViewData["AddressId"] = new SelectList(_context.Addresses, "AddressId", "City", supplier.AddressId);
            return View(svm);
        }

        // POST: Suppliers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SupplierId,Name,Telephone,AccountNumber,AddressId")] Supplier supplier)
        {
            Supplier supplierContext = new Supplier() {
                SupplierId = id,
                Name = supplier.Name,
                Telephone = supplier.Telephone,
                AccountNumber = supplier.AccountNumber,
                AddressId = supplier.AddressId
            };


            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(supplierContext);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SupplierExists(supplierContext.SupplierId))
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
            ViewData["AddressId"] = new SelectList(_context.Addresses, "AddressId", "City", supplier.AddressId);
            return View(supplier);
        }

        // GET: Suppliers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supplier = await _context.Suppliers
                .Include(s => s.Address)
                .FirstOrDefaultAsync(m => m.SupplierId == id);
            if (supplier == null)
            {
                return NotFound();
            }

            return View(supplier);
        }

        // POST: Suppliers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var supplier = await _context.Suppliers.FindAsync(id);
            _context.Suppliers.Remove(supplier);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SupplierExists(int id)
        {
            return _context.Suppliers.Any(e => e.SupplierId == id);
        }
    }
}
