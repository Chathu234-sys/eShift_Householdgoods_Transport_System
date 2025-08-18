using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eShiftCompany.Models;

namespace eShiftCompany.Repository.Interface
{
    public interface IAdminDashboardRepository
    {
        List<AdminDashboardModel> GetAllAdmins();
        AdminDashboardModel GetAdminById(int adminId);
        void AddAdmin(AdminDashboardModel admin);
        void DeleteAdmin(int adminId);
    }
}
