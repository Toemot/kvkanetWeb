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
            return View(_repository.GetAllEmployees());
        }

        public ViewResult Details(int id)
        {
            var viewModel = new HomeDetailsViewModel
            {
                Employee = _repository.GetEmployee(1),
                PageTitle = "Employee Details"
            };
            
            return View(viewModel);
        }
    }
}
