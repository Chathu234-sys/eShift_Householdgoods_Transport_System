using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eShiftCompany.Models;

namespace eShiftCompany.Business.Interface
{
    public interface IAdminDashboardService
    {
        List<AdminDashboardModel> GetAllAdmins();
        AdminDashboardModel GetAdminById(int adminId);
        void AddAdmin(AdminDashboardModel admin);
        void DeleteAdmin(int adminId);
    }  
}
