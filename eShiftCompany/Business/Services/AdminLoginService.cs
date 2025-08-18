using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eShiftCompany.Models;
using eShiftCompany.Business.Interface;
using eShiftCompany.Repository.Interface;

namespace eShiftCompany.Business.Services
{
    public class AdminLoginService : IAdminLoginService
    {
        private readonly IAdminLoginRepository _repository;

        public AdminLoginService(IAdminLoginRepository repository)
        {
            _repository = repository;
        }

        public bool Login(AdminLoginModel admin)
        {
            return _repository.ValidateLogin(admin);
        }
    }
}
