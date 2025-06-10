using Microsoft.AspNetCore.Mvc;
using MVC_Proj.Models;
using MVC_Proj.Models.Entities;

namespace MVC_Proj.Controllers
{
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;

        public ProductController(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }

        // GET: ProductController
        public IActionResult Index()
        {
            var products = _context.Products.ToList();
            return View(products); // Pass model to view
        }

        // GET: ProductController/Show/5
        [HttpGet]
        public IActionResult Show(int productId)
        {
            var product = _context.Products.SingleOrDefault(p => p.ProductId == productId);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // GET: ProductController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Product product)
        {
            try
            {
                _context.Products.Add(product);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(product);
            }
        }

        // GET: ProductController/Edit/5
        public IActionResult Edit(int productId)
        {
            var dbProduct = _context.Products.SingleOrDefault(p => p.ProductId == productId);
            if (dbProduct == null)
            {
                return NotFound();
            }
            return View(dbProduct); // Pass model to the view
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Product product)
        {
            try
            {
                var dbProduct = _context.Products.SingleOrDefault(p => p.ProductId == product.ProductId);
                if (dbProduct == null)
                {
                    return NotFound();
                }

                dbProduct.ProductName = product.ProductName;
                dbProduct.ProductDescription = product.ProductDescription;
                dbProduct.ProductStock = product.ProductStock;
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(product);
            }
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int productId)
        {
            try
            {
                var dbProduct = _context.Products.SingleOrDefault(p => p.ProductId == productId);
                if (dbProduct == null)
                {
                    return NotFound();
                }

                _context.Products.Remove(dbProduct);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}