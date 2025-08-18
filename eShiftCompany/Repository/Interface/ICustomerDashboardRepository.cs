using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eShiftCompany.Models;

namespace eShiftCompany.Repository.Interface
{
    public interface ICustomerDashboardRepository
    {
        List<string> GetCustomerIDs();
        List<string> GetCategories();
        List<string> GetItemsByCategory(string category);
        int GetProductIdByName(string productName);
        int CreateJob(int customerId, string startLocation, string destination, decimal distance, int itemCount, string description, DateTime jobDate);
        void InsertJobItem(int jobId, int productId);
    }
}
