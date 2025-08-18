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
    public class ManageStatusService : IManageStatusService
    {
        private readonly IManageStatusRepository _repository;

        public ManageStatusService(IManageStatusRepository repository)
        {
            _repository = repository;
        }

        public List<ManageStatusModel> GetAllJobs()
        {
            return _repository.GetAllJobs();
        }

        public bool ChangeJobStatus(int jobId, string newStatus)
        {
            return _repository.UpdateJobStatus(jobId, newStatus);
        }

        public bool EditJob(ManageStatusModel job)
        {
            return _repository.UpdateJobDetails(job);
        }

        public ManageStatusModel GetJob(int jobId)
        {
            return _repository.GetJobById(jobId);
        }
    }
}
