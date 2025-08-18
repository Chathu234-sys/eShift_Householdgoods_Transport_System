using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShiftCompany.Models
{
    public class PaymentsModel
    {
        public int PaymentID { get; set; }
        public int JobID { get; set; }
        public int CustomerID { get; set; }
        public decimal Amount { get; set; }
        public string PaymentStatus { get; set; }
        public DateTime PaymentDate { get; set; }
        public object SecureSocketOptions { get; private set; }
    }
}
