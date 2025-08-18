using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eShiftCompany.Models;

namespace eShiftCompany.Business.Interface
{
    public interface IAdminLoginService
    {
        bool Login(AdminLoginModel admin);
    }
}
