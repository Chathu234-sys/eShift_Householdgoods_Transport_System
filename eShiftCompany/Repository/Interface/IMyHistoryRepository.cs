using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eShiftCompany.Models;

namespace eShiftCompany.Repository.Interface
{
    public interface IMyHistoryRepository
    {
        (string Name, string Email, string Contact) GetCustomerProfile(int customerId);
        List<MyHistoryModel> GetUpcomingJobs(int customerId);
        List<MyHistoryModel> GetJobHistory(int customerId);
    }
}
