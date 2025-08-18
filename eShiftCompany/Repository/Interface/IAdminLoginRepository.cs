using eShiftCompany.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShiftCompany.Repository.Interface
{
    public interface IAdminLoginRepository
    {
        bool ValidateLogin(AdminLoginModel admin);
    }
}
