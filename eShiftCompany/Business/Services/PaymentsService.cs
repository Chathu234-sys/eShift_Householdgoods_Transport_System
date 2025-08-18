using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eShiftCompany.Models;
using eShiftCompany.Repository.Interface;
using eShiftCompany.Business.Interface;
using eShiftCompany.Repository.Services;

namespace eShiftCompany.Business.Services
{
    public class PaymentsService : IPaymentsService
    {
        private readonly IPaymentsRepository _paymentRepository;

        public PaymentsService(IPaymentsRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        public List<int> GetPendingOrAcceptedJobIds()
        {
            return _paymentRepository.GetPendingOrAcceptedJobIds();
        }

        public List<PaymentsModel> GetAllPayments()
        {
            return _paymentRepository.GetAllPayments();
        }

        public decimal CalculateAmount(int jobId)
        {
            return _paymentRepository.CalculateAmount(jobId);
        }

        public void ProcessPayment(int jobId, decimal amount)
        {
            _paymentRepository.ProcessPayment(jobId, amount);
        }

        public void CancelJobPayment(int jobId)
        {
            _paymentRepository.CancelJobPayment(jobId);
        }

        public string GetCustomerEmail(int jobId)
        {
            return _paymentRepository.GetCustomerEmail(jobId);
        }
    }
}
