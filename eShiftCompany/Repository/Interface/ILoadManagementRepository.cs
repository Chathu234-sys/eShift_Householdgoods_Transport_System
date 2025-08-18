using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eShiftCompany.Models;
using System.Data;

namespace eShiftCompany.Repository.Interface
{
    public interface ILoadManagementRepository
    {
        void AddLoad(LoadManagementModel load);
        void UpdateLoad(LoadManagementModel load);
        void DeleteLoad(int loadId);
        LoadManagementModel GetLoadById(int loadId);
        DataTable GetAllLoads();
        DataTable GetLoadsByJobId(int jobId);
        DataTable GetPendingJobs();
    }
}
