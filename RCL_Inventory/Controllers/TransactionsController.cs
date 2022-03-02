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
        public async Task<IActionResult> Index()
        {
            var inventoryContext = _context.Transaction.Include(t => t.Product).Include(t => t.TransactionType);
            return View(await inventoryContext.ToListAsync());
        }

        // GET: Transactions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transaction = await _context.Transaction
                .Include(t => t.Product)
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



            PurchaseProductViewModels ppvw = new PurchaseProductViewModels()
            {
                ProductsList = products,
                SuppliersList = suppliers
            };
            return View(ppvw);
        }


        
        //[HttpPost]
        //public IActionResult CreatePurchase(Transaction transaction)
        //{
        //    var products = _context.Products.Include(t => t.Category).ToList(); ;

        //    //Transaction transactionBuilder = new Transaction()
        //    //{
        //    //    ProductId = 1,
        //    //    CategoryId =1,
        //    //    Quantity = 1,
        //    //    TransactionTypeId = 1

        //    //};
        //    if (ModelState.IsValid)
        //    {
        //        _context.Transaction.Add(transaction);
        //    return RedirectToAction("Index");
        //    }
             
        //    return View(transaction);
        //}


        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreatePurchase([Bind("TransactionId,Date,ProductId,Quantity,TransactionTypeId,SupplierId")] Transaction transaction)
        {

            var productId = transaction.ProductId;

            var productContext = _context.Products.Find(productId);

            int categoryInt = productContext.CategoryId;


           // PurchaseProductViewModels trans = new PurchaseProductViewModels();

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
                _context.Add(transactionContext);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "Name", transaction.ProductId);
            ViewData["TransactionTypeId"] = new SelectList(_context.TransactionTypes, "TransactionTypeId", "Name", transaction.TransactionTypeId);
            return View(transaction);
        }




        // GET: Transactions/Delete/5
        public async Task<IActionResult> PurchaseProduct(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transaction = await _context.Transaction
                .Include(t => t.Product)
                .Include(t => t.TransactionType)
                .FirstOrDefaultAsync(m => m.TransactionId == id);
            if (transaction == null)
            {
                return NotFound();
            }

            return View(transaction);
        }

        //PurchaseProduct

        //public async Task<IActionResult> Create([Bind("TransactionId,Date,CategoryId,ProductId,TransactionTypeId")] Transaction transaction)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(transaction);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "Name", transaction.ProductId);
        //    ViewData["TransactionTypeId"] = new SelectList(_context.TransactionTypes, "TransactionTypeId", "Name", transaction.TransactionTypeId);
        //    return View(transaction);
        //}




        //public IActionResult CategoryRefresh(int categoryId)
        //{
        //    var productList = new List<Product>();



        //    return View();
        //}



        // POST: Transactions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TransactionId,Date,CategoryId,ProductId,Quantity,TransactionTypeId")] Transaction transaction)
        {
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
            if (id == null)
            {
                return NotFound();
            }

            var transaction = await _context.Transaction.FindAsync(id);
            if (transaction == null)
            {
                return NotFound();
            }
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "Name", transaction.ProductId);
            ViewData["TransactionTypeId"] = new SelectList(_context.TransactionTypes, "TransactionTypeId", "Name", transaction.TransactionTypeId);
            return View(transaction);
        }

        // POST: Transactions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TransactionId,Date,CategoryId,ProductId,Quantity,TransactionTypeId")] Transaction transaction)
        {
            if (id != transaction.TransactionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(transaction);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TransactionExists(transaction.TransactionId))
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
