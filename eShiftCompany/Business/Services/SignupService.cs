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
    public class SignupService : ISignupService
    {
        private readonly ISignupRepository _repository;

        public SignupService(ISignupRepository repository)
        {
            _repository = repository;
        }

        public void RegisterCustomer(SignupModel model)
        {
            _repository.InsertCustomer(model);
        }

        public SignupModel GetCustomerByRegNo(int regNo)
        {
            return _repository.GetCustomer(regNo);
        }

        public void UpdateCustomer(SignupModel model)
        {
            _repository.UpdateCustomer(model);
        }

        public void DeleteCustomer(int regNo)
        {
            _repository.DeleteCustomer(regNo);
        }

        public List<int> GetAllCustomerIds()
        {
            return _repository.GetAllCustomerIds();
        }
    }

}
