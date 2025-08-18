using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eShiftCompany.Models;
using eShiftCompany.Business.Interface;

namespace eShiftCompany.Business.Interface
{
    public interface IPaymentsService
    {
        List<int> GetPendingOrAcceptedJobIds();
        List<PaymentsModel> GetAllPayments();
        decimal CalculateAmount(int jobId);
        void ProcessPayment(int jobId, decimal amount);
        void CancelJobPayment(int jobId);
        string GetCustomerEmail(int jobId);
    }
}
