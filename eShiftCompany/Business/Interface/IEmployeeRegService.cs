using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eShiftCompany.Models;

namespace eShiftCompany.Business.Interface
{
    public interface IEmployeeRegService
    {
        void AddEmployee(EmployeeRegModel emp);
        void UpdateEmployee(EmployeeRegModel emp);
        void DeleteEmployee(int employeeId);
        EmployeeRegModel GetEmployeeById(int employeeId);
        List<EmployeeRegModel> GetAllEmployees();
    }
}
