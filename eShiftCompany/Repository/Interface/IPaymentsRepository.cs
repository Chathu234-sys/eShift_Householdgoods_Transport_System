using eShiftCompany.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eShiftCompany.Repository.Interface;

namespace eShiftCompany.Repository.Interface
{
    public interface IPaymentsRepository
    {
        List<int> GetPendingJobIDs();
        decimal CalculateAmount(int jobId);
        string GetCustomerEmailByJobID(int jobId);
        void InsertPayment(PaymentsModel payment);
        void CancelPayment(int jobId);
        void UpdateJobStatus(int jobId, string status);
        List<PaymentsModel> GetAllPayments();
        List<int> GetPendingOrAcceptedJobIds();
        string GetCustomerEmail(int jobId);
        void ProcessPayment(int jobId, decimal amount);
        void CancelJobPayment(int jobId);
    }
}
