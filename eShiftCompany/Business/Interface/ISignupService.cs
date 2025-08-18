using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eShiftCompany.Models;

namespace eShiftCompany.Business.Interface
{
    public interface ISignupService
    {
        void RegisterCustomer(SignupModel model);
        SignupModel GetCustomerByRegNo(int regNo);
        void UpdateCustomer(SignupModel model);
        void DeleteCustomer(int regNo);
        List<int> GetAllCustomerIds();
    }
}
