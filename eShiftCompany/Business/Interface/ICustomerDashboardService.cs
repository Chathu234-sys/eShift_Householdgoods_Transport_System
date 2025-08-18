using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eShiftCompany.Models;

namespace eShiftCompany.Business.Interface
{
    public interface ICustomerDashboardService
    {
        List<string> GetCustomerIDs();
        List<string> GetCategories();
        List<string> GetItemsByCategory(string category);
        int GetProductIdByName(string name);
        int CreateJob(int customerId, string start, string dest, decimal distance, int itemCount, string desc, DateTime jobDate);
        void InsertJobItem(int jobId, int productId);
    }
}
