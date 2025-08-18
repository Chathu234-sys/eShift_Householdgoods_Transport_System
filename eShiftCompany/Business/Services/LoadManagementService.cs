using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eShiftCompany.Business.Interface;
using eShiftCompany.Models;
using eShiftCompany.Repository;
using eShiftCompany.Repository.Interface;
using eShiftCompany.Repository.Services;
using System.Data;
using System.Data.SqlClient;

namespace eShiftCompany.Business.Services
{
    public class LoadManagementService : ILoadManagementService
    {
        private readonly ILoadManagementRepository _repository;

        public LoadManagementService()
        {
            _repository = new LoadManagementRepository();
        }

        public void AddLoad(LoadManagementModel load) => _repository.AddLoad(load);
        public void UpdateLoad(LoadManagementModel load) => _repository.UpdateLoad(load);
        public void DeleteLoad(int loadId) => _repository.DeleteLoad(loadId);
        public LoadManagementModel GetLoadById(int loadId) => _repository.GetLoadById(loadId);
        public DataTable GetAllLoads() => _repository.GetAllLoads();
        public DataTable GetLoadsByJobId(int jobId) => _repository.GetLoadsByJobId(jobId);
        public DataTable GetPendingJobs() => _repository.GetPendingJobs();
    }
}
