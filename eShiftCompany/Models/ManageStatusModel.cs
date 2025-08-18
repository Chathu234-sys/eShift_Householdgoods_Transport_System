using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShiftCompany.Models
{
    public class ManageStatusModel
    {
        public int JobID { get; set; }
        public string Status { get; set; }
        public string PaymentStatus { get; set; }
        public string StartLocation { get; set; }
        public string Destination { get; set; }
        public decimal Distance { get; set; }
        public int NumberOfItems { get; set; }
        public string Description { get; set; }
        public DateTime JobDate { get; set; }
    }
}
