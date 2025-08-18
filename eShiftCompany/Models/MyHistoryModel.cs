using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShiftCompany.Models
{
    public class MyHistoryModel
    {
        public int JobID { get; set; }
        public string StartLocation { get; set; }
        public string Destination { get; set; }
        public DateTime JobDate { get; set; }
        public string Status { get; set; }
    }
}
