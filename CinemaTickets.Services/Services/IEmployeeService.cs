using CinemaTickets.DataModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaTickets.Services.Services
{
    public interface IEmployeeService
    {
        IQueryable<Employee> GetAllEmployees();
        Employee GetEmployeeById(int id);
        Employee GetEmployeeByEmail(string email);
        void AddEmployee(Employee employee);
    }
}
