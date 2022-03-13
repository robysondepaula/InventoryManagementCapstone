using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RCL_Inventory.Models;
using RCL_Inventory.Models.ViewModels;

namespace RCL_Inventory.Controllers
{
    public class TransactionsController : Controller
    {
        private readonly InventoryContext _context;

        public TransactionsController(InventoryContext context)
        {
            _context = context;
        }

        // GET: Transactions
        [HttpGet]
        public async Task<IActionResult> Index()
        {

            var transaction = await _context.Transaction
                .Include(t => t.Product)
                 .Include(t => t.Product.Category)
                .Include(t => t.Supplier)
                .Include(t => t.TransactionType).ToListAsync();

            var products = _context.Products.Include(t => t.Category).ToList(); ;
            var suppliers = _context.Suppliers.Include(t => t.Address).ToList();
            var categories = _context.Categories.ToList();
            var transactions = _context.Transaction.Include(t=>t.TransactionType).ToList();

            PurchaseProductViewModels ppvw = new PurchaseProductViewModels()
            {
                ProductsList = products,
                SuppliersList = suppliers,
                CategoriesList = categories,
                TransactionsList = transaction,
                
            };



            ViewData["TransactionTypeId"] = new SelectList(_context.TransactionTypes, "TransactionTypeId", "Name");

            return View(ppvw);
        }

        [HttpPost]
        public async Task<IActionResult> Index(int? id)
        { 

            var transaction = _context.Transaction
          .Include(t => t.Product)
           .Include(t => t.Product.Category)
          .Include(t => t.Supplier)
          .Include(t => t.TransactionType).Where(t => t.TransactionTypeId == id.Value).ToList();

            List<Transaction> transactionFilter = new List<Transaction>();
     

            var products = _context.Products.Include(t => t.Category).ToList();
            var suppliers = _context.Suppliers.Include(t => t.Address).ToList();
            var categories = _context.Categories.ToList();
            //var transactions = _context.Transaction.Include(t => t.TransactionType).Where(t => t.TransactionTypeId == id.Value).ToListAsync();
            PurchaseProductViewModels ppvw = new PurchaseProductViewModels()
            {
                ProductsList = products,
                SuppliersList = suppliers,
                CategoriesList = categories,
                TransactionsList = transaction,
                TransactionTypeId = id.Value
            };


            ViewData["TransactionTypeId"] = new SelectList(_context.TransactionTypes, "TransactionTypeId", "Name");

            return View("Index",ppvw);
        }


        //public async Task<IActionResult> IndexSales(int? id)
        //{

        //    var transaction = await _context.Transaction
        //        .Include(t => t.Product)
        //         .Include(t => t.Product.Category)
        //        .Include(t => t.Supplier)
        //        .Include(t => t.TransactionType).ToListAsync();

        //    var products = _context.Products.Include(t => t.Category).ToList(); ;
        //    var suppliers = _context.Suppliers.Include(t => t.Address).ToList();
        //    var categories = _context.Categories.ToList();
        //    var transactions = _context.Transaction.Include(t => t.TransactionType).ToList();

        //    PurchaseProductViewModels ppvw = new PurchaseProductViewModels()
        //    {
        //        ProductsList = products,
        //        SuppliersList = suppliers,
        //        CategoriesList = categories,
        //        TransactionsList = transactions
        //    };



        //    ViewData["TransactionTypeId"] = new SelectList(_context.TransactionTypes, "TransactionTypeId", "Name");

        //    return View(ppvw);
        //}


        // GET: Transactions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transaction = await _context.Transaction
                .Include(t => t.Product)
                 .Include(t => t.Product.Category)
                .Include(t=>t.Supplier)
                .Include(t => t.TransactionType)
                .FirstOrDefaultAsync(m => m.TransactionId == id);
            if (transaction == null)
            {
                return NotFound();
            }

            return View(transaction);
        }

        // GET: Transactions/Create
        public IActionResult Create()
        {
            //alterado
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "Name");
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "Name");
            ViewData["TransactionTypeId"] = new SelectList(_context.TransactionTypes, "TransactionTypeId", "Name");
            return View();
        }

        //Criando a multimodel operation
        // GET: Transactions/Create
        [HttpGet]
        public IActionResult CreatePurchase()
        {
            var products = _context.Products.Include(t => t.Category).ToList(); ;
            var suppliers = _context.Suppliers.Include(t => t.Address).ToList();
            var categories = _context.Categories.ToList();



            PurchaseProductViewModels ppvw = new PurchaseProductViewModels()
            {
                ProductsList = products,
                SuppliersList = suppliers,
                CategoriesList = categories

            };
            return View(ppvw);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreatePurchase([Bind("TransactionId,Date,ProductId,Quantity,TransactionTypeId,SupplierId")] Transaction transaction)
        {

            var productId = transaction.ProductId;

            var productContext = _context.Products.Find(productId);

            int categoryInt = productContext.CategoryId;


            Transaction transactionContext = new Transaction()
            {
                Date = transaction.Date,
                CategoryId = categoryInt,
                ProductId = transaction.ProductId,
                Quantity = transaction.Quantity,
                TransactionTypeId = transaction.TransactionTypeId,
                SupplierId = transaction.SupplierId   
            };

            if (ModelState.IsValid)
            {
                _context.Add(transaction);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "Name", transaction.ProductId);
            ViewData["TransactionTypeId"] = new SelectList(_context.TransactionTypes, "TransactionTypeId", "Name", transaction.TransactionTypeId);
            return View(transaction);
        }

        // GET: Transactions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var products = await _context.Products.Include(t => t.Category).ToListAsync();
            var suppliers = await _context.Suppliers.Include(t => t.Address).ToListAsync();
            var transaction = await _context.Transaction.FindAsync(id);


            int transactionId = transaction.TransactionId;
            var ppvw = new PurchaseProductViewModels()
            {
                ProductsList = products,
                SuppliersList = suppliers,
                TransactionId = transactionId
            };
            return View(ppvw);
           
        }

        // POST: Transactions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TransactionId,Date,ProductId,Quantity,TransactionTypeId,SupplierId")] Transaction transaction)
        {
   
            var productId = transaction.ProductId;

            var productContext = _context.Products.Find(productId);

            int categoryInt = productContext.CategoryId;

            Transaction transactionContext = new Transaction()
            {
                Date = transaction.Date,
                CategoryId = categoryInt,
                ProductId = transaction.ProductId,
                Quantity = transaction.Quantity,
                TransactionTypeId = transaction.TransactionTypeId,
                SupplierId = transaction.SupplierId,
                TransactionId = id
                
            };

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(transactionContext);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TransactionExists(transactionContext.TransactionId))
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
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "Name", transaction.ProductId);
            ViewData["TransactionTypeId"] = new SelectList(_context.TransactionTypes, "TransactionTypeId", "Name", transaction.TransactionTypeId);
            return View(transaction);
        }

        // GET: Transactions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transaction = await _context.Transaction
                .Include(t => t.Product)
                .Include(t => t.Product.Category)
                .Include(t=>t.Supplier)
                .Include(t => t.TransactionType)
                .FirstOrDefaultAsync(m => m.TransactionId == id);
            if (transaction == null)
            {
                return NotFound();
            }

            return View(transaction);
        }

        // POST: Transactions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var transaction = await _context.Transaction.FindAsync(id);
            _context.Transaction.Remove(transaction);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TransactionExists(int id)
        {
            return _context.Transaction.Any(e => e.TransactionId == id);
        }
    }
}
