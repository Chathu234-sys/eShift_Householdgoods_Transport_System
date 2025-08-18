using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eShiftCompany.Models;
using eShiftCompany.Repository.Interface;
using eShiftCompany.Business.Interface;

namespace eShiftCompany.Business.Services
{
    public class MyHistoryService : IMyHistoryService
    {
        private readonly IMyHistoryRepository _repo;

        public MyHistoryService(IMyHistoryRepository repo)
        {
            _repo = repo;
        }

        public (string Name, string Email, string Contact) GetCustomerProfile(int customerId)
        {
            return _repo.GetCustomerProfile(customerId);
        }

        public List<MyHistoryModel> GetUpcomingJobs(int customerId)
        {
            return _repo.GetUpcomingJobs(customerId);
        }

        public List<MyHistoryModel> GetJobHistory(int customerId)
        {
            return _repo.GetJobHistory(customerId);
        }
    }
}
