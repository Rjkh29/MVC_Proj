using Microsoft.AspNetCore.Mvc;
using MVC_Proj.Models;
using MVC_Proj.Models.Entities;

namespace MVC_Proj.Controllers
{
    public class CustomerController : Controller
    {
        private readonly AppDbContext _context;

        public CustomerController(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }

        // GET: CustomerController
        public IActionResult Index()
        {
            var customers = _context.Customers.ToList();
            return View(customers); // Pass customers list to the view
        }

        // GET: CustomerController/Show/5
        [HttpGet]
        public IActionResult Show(int customerId)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.CustomerId == customerId);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        // GET: CustomerController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CustomerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Customer customer)
        {
            try
            {
                _context.Customers.Add(customer);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(customer);
            }
        }

        // GET: CustomerController/Edit/5
        public IActionResult Edit(int customerId)
        {
            var dbCustomer = _context.Customers.SingleOrDefault(c => c.CustomerId == customerId);
            if (dbCustomer == null)
            {
                return NotFound();
            }
            return View(dbCustomer); // Pass model to the view
        }

        // POST: CustomerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Customer customer)
        {
            try
            {
                var dbCustomer = _context.Customers.SingleOrDefault(c => c.CustomerId == customer.CustomerId);
                if (dbCustomer == null)
                {
                    return NotFound();
                }

                dbCustomer.CustomerName = customer.CustomerName;
                dbCustomer.CustomerEmail = customer.CustomerEmail;
                dbCustomer.CustomerAddress = customer.CustomerAddress;
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(customer);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int customerId)
        {
            try
            {
                var dbCustomer = _context.Customers.SingleOrDefault(c => c.CustomerId == customerId);
                if (dbCustomer == null)
                {
                    return NotFound();
                }

                _context.Customers.Remove(dbCustomer);
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