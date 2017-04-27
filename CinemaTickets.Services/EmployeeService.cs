using CinemaTickets.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinemaTickets.DataModel.Models;
using CinemaTickets.DataModel;

namespace CinemaTickets.Services
{
    public class EmployeeService : IEmployeeService
    {
        private CinemaTicketsDbContext _context;
        public EmployeeService()
        {
            _context = new CinemaTicketsDbContext();
        }
        public void AddEmployee(Employee employee)
        {
            this._context.Employees.Add(employee);
            this._context.SaveChanges();
        }

        public IQueryable<Employee> GetAllEmployees()
        {
            return this._context.Employees;
        }

        public Employee GetEmployeeByEmail(string email)
        {
            return this._context.Employees.FirstOrDefault(e => e.Email == email);
        }

        public Employee GetEmployeeById(int id)
        {
            return this._context.Employees.FirstOrDefault(e => e.EmployeeID == id);
        }
    }
}
