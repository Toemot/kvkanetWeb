using EmpKud.Models;
using EmpKud.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmpKud.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmployeeRepository _repository;

        public HomeController(IEmployeeRepository employee)
        {
            _repository = employee;
        }

        public ViewResult Index()
        {
            var model = _repository.GetAllEmployees();
            return View(model);
        }

        public ViewResult Details(int? id)
        {
            var viewModel = new HomeDetailsViewModel
            {
                Employee = _repository.GetEmployee(id??1),
                PageTitle = "Employee Details"
            };
            
            return View(viewModel);
        }

        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                var newEmployee = _repository.Add(employee);
                return RedirectToAction("details", new { id = newEmployee.Id });
            }
            return View();
        }
    }
}
