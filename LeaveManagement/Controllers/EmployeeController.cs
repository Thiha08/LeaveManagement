using LeaveManagement.Infra.Data;
using LeaveManagement.Infra.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeaveManagement.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly LeaveDbContext _dbContext;

        public EmployeeController(LeaveDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var query = _dbContext.Employees.AsQueryable()
                .Where(x => x.Age > 30);

            query = query.OrderByDescending(x => x.Name);

            List<Employee> employees = query.ToList();

            return View(employees);
        }

        [HttpGet]
        public ActionResult Create(int? id)
        {
            Employee employee = _dbContext.Employees.FirstOrDefault(x => x.Id == id);

            if (employee == null)
            {
                employee = new Employee();
                employee.JoinedDate = DateTime.Now;
            }
           
            return View(employee);
        }

        [HttpPost]
        public ActionResult Create(Employee viewModel)
        {
            if (viewModel.Id == 0)
            {
                _dbContext.Employees.Add(viewModel);
            }
            else
            {
                _dbContext.Employees.Update(viewModel);
            }

            ViewBag.CurrentDepartmentId = new List<int>
            {
                1,
                2,
                3,
            };

            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            Employee employee = _dbContext.Employees.FirstOrDefault(x => x.Id == id);
            return View(employee);
        }

        [HttpPost]
        public ActionResult Update(Employee viewModel)
        {
            _dbContext.Employees.Update(viewModel);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(Employee viewModel)
        {
            _dbContext.Employees.Remove(viewModel);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
