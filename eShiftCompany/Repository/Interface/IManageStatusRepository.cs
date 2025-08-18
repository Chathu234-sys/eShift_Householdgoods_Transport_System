using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eShiftCompany.Models;

namespace eShiftCompany.Repository.Interface
{
    public interface IManageStatusRepository
    {
        List<ManageStatusModel> GetAllJobs();
        bool UpdateJobStatus(int jobId, string newStatus);
        bool UpdateJobDetails(ManageStatusModel job);
        ManageStatusModel GetJobById(int jobId);
    }
}
