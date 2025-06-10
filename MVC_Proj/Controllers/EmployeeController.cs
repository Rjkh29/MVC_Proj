using Microsoft.AspNetCore.Mvc;
using MVC_Proj.Models;
using MVC_Proj.Models.Entities;

namespace MVC_Proj.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly AppDbContext _context;

        public EmployeeController(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }

        // GET: EmployeeController
        public IActionResult Index()
        {
            var employees = _context.Employees.ToList();
            return View(employees); // Pass model to view
        }

        // GET: EmployeeController/Show/5
        [HttpGet]
        public IActionResult Show(int id)
        {
            var employee = _context.Employees.SingleOrDefault(e => e.EmployeeId == id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        // GET: EmployeeController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Employee employee)
        {
            try
            {
                _context.Employees.Add(employee);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(employee);
            }
        }

        // GET: EmployeeController/Edit/5
        public IActionResult Edit(int id)
        {
            var dbEmployee = _context.Employees.SingleOrDefault(e => e.EmployeeId == id);
            if (dbEmployee == null)
            {
                return NotFound();
            }
            return View(dbEmployee); // Ensure model is passed
        }

        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Employee employee)
        {
            try
            {
                var dbEmployee = _context.Employees.SingleOrDefault(e => e.EmployeeId == employee.EmployeeId);
                if (dbEmployee == null)
                {
                    return NotFound();
                }

                dbEmployee.EmployeeName = employee.EmployeeName;
                dbEmployee.EmployeePosition = employee.EmployeePosition;
                dbEmployee.EmployeeDepartment = employee.EmployeeDepartment;
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(employee);
            }
        }



        // POST: EmployeeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int employeeId)
        {
            try
            {
                var dbEmployee = _context.Employees.SingleOrDefault(e => e.EmployeeId == employeeId);
                if (dbEmployee == null)
                {
                    return NotFound();
                }

                _context.Employees.Remove(dbEmployee);
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