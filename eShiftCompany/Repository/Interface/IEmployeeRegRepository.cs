using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eShiftCompany.Models;

namespace eShiftCompany.Repository.Interface
{
    public interface IEmployeeRegRepository
    {
        void AddEmployee(EmployeeRegModel emp);
        void UpdateEmployee(EmployeeRegModel emp);
        void DeleteEmployee(int employeeId);
        EmployeeRegModel GetEmployeeById(int employeeId);
        List<EmployeeRegModel> GetAllEmployees();
    }
}
