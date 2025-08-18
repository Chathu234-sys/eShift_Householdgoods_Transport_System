using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eShiftCompany.Models;
using eShiftCompany.Business.Interface;
using eShiftCompany.Repository.Interface;

namespace eShiftCompany.Business.Services
{
    public class EmployeeRegService : IEmployeeRegService
    {
        private readonly IEmployeeRegRepository _repo;

        public EmployeeRegService(IEmployeeRegRepository repo)
        {
            _repo = repo;
        }

        public void AddEmployee(EmployeeRegModel emp)
        {
            _repo.AddEmployee(emp);
        }

        public void UpdateEmployee(EmployeeRegModel emp)
        {
            _repo.UpdateEmployee(emp);
        }

        public void DeleteEmployee(int employeeId)
        {
            _repo.DeleteEmployee(employeeId);
        }

        public EmployeeRegModel GetEmployeeById(int employeeId)
        {
            return _repo.GetEmployeeById(employeeId);
        }

        public List<EmployeeRegModel> GetAllEmployees()
        {
            return _repo.GetAllEmployees();
        }
    }
}
