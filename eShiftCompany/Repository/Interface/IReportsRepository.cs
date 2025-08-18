using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using eShiftCompany.Models;

namespace eShiftCompany.Repository.Interface
{
    public interface IReportsRepository
    {
        DataTable GetJobUtilization(DateTime from, DateTime to);
        DataTable GetAllJobDetails(DateTime from, DateTime to);
        DataTable GetPayments(DateTime from, DateTime to);
        DataTable GetCustomers();
        DataTable GetEmployees();
    }
}
