using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmpKud.Models
{
    public class MockEmployeeRepository : IEmployeeRepository
    {
        private IList<Employee> _employees;

        public MockEmployeeRepository()
        {
            _employees = new List<Employee>()
            {
                new Employee { Id = 1, Name = "Rica Foo", Email = "r.foo@us.com", Department = "ITech"},
                new Employee { Id = 2, Name = "Sese Beans", Email = "s.beans@us.com", Department = "FinTech"},
                new Employee { Id = 3, Name = "Charles Rice", Email = "c.rice@us.com", Department = "payRoll"},
            };
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _employees;
        }

        public Employee GetEmployee(int id)
        {
            return _employees.FirstOrDefault(e => e.Id == id);
        }
    }
}
