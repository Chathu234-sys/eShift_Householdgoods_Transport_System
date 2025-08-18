using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eShiftCompany.Business.Interface;
using eShiftCompany.Models;
using eShiftCompany.Repository.Interface;

namespace eShiftCompany.Business.Services
{
    public class CustomerDashboardService : ICustomerDashboardService
    {
        private readonly ICustomerDashboardRepository _repo;

        public CustomerDashboardService(ICustomerDashboardRepository repo)
        {
            _repo = repo;
        }

        public List<string> GetCustomerIDs() => _repo.GetCustomerIDs();
        public List<string> GetCategories() => _repo.GetCategories();
        public List<string> GetItemsByCategory(string category) => _repo.GetItemsByCategory(category);
        public int GetProductIdByName(string name) => _repo.GetProductIdByName(name);
        public int CreateJob(int customerId, string start, string dest, decimal distance, int itemCount, string desc, DateTime jobDate)
            => _repo.CreateJob(customerId, start, dest, distance, itemCount, desc, jobDate);
        public void InsertJobItem(int jobId, int productId) => _repo.InsertJobItem(jobId, productId);
    }
}
