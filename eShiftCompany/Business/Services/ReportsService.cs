using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eShiftCompany.Business.Interface;
using eShiftCompany.Repository.Interface;
using System.Data;
using eShiftCompany.Models;
namespace eShiftCompany.Business.Services
{
    public class ReportsService : IReportsService
    {
        private readonly IReportsRepository _repository;

        public ReportsService(IReportsRepository repository)
        {
            _repository = repository;
        }

        public DataTable GenerateReport(string type, DateTime from, DateTime to)
        {
            if (type == "Job Utilization")
            {
                return _repository.GetJobUtilization(from, to);
            }
            else if (type == "All Job Details")
            {
                return _repository.GetAllJobDetails(from, to);
            }
            else if (type == "Payments")
            {
                return _repository.GetPayments(from, to);
            }
            else if (type == "Customers")
            {
                return _repository.GetCustomers();
            }
            else if (type == "Employees")
            {
                return _repository.GetEmployees();
            }
            else
            {
                throw new ArgumentException("Invalid report type.");
            }
        }
    }
}
