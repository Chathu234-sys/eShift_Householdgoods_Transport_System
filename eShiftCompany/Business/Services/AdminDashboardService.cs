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
    public class AdminDashboardService : IAdminDashboardService
    {
        private readonly IAdminDashboardRepository _repository;

        public AdminDashboardService(IAdminDashboardRepository repository)
        {
            _repository = repository;
        }

        public List<AdminDashboardModel> GetAllAdmins()
        {
            return _repository.GetAllAdmins();
        }

        public AdminDashboardModel GetAdminById(int adminId)
        {
            return _repository.GetAdminById(adminId);
        }

        public void AddAdmin(AdminDashboardModel admin)
        {
            _repository.AddAdmin(admin);
        }

        public void DeleteAdmin(int adminId)
        {
            _repository.DeleteAdmin(adminId);
        }
    }
}