using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eShiftCompany.Models;

namespace eShiftCompany.Business.Interface
{
    public interface IManageStatusService
    {
        List<ManageStatusModel> GetAllJobs();
        bool ChangeJobStatus(int jobId, string newStatus);
        bool EditJob(ManageStatusModel job);
        ManageStatusModel GetJob(int jobId);
    }
}
