using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using eShiftCompany.Models;
using System.Data.SqlClient;

namespace eShiftCompany.Business.Interface
{
    public interface IReportsService
    {
        DataTable GenerateReport(string type, DateTime from, DateTime to);
    }
}
