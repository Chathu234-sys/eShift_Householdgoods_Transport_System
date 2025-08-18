using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eShiftCompany.Models;

namespace eShiftCompany.Repository.Interface
{
    public interface ISignupRepository
    {
        void InsertCustomer(SignupModel model);
        SignupModel GetCustomer(int regNo);
        void UpdateCustomer(SignupModel model);
        void DeleteCustomer(int regNo);
        List<int> GetAllCustomerIds();
    }
}
