using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShiftCompany.Models
{
    public class LoadManagementModel
    {
        public int LoadID { get; set; }
        public int JobID { get; set; }
        public string Description { get; set; }
        public decimal Weight { get; set; }
        public decimal Volume { get; set; }
        public string SpecialHandling { get; set; }
        public int LorryID { get; set; }
        public int DriverID { get; set; }
        public int AssistantID { get; set; }
        public int ContainerID { get; set; }
    }
}
