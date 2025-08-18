using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShiftCompany.Models
{
    public class TransportUnitManagementModel
    {
        public int ID { get; internal set; }
        public string Type { get; set; }  // Lorry or Container
        public string PlateOrContainerNumber
        {
            get => PlateOrContainer;
            set => PlateOrContainer = value;
        }// PlateNumber or ContainerNumber
        public string ModelOrSize { get; set; }            // Model (Lorry) or Size (Container)
        public decimal Capacity { get; set; }
        public string Status { get; set; }                 // Free, In-Use, Maintenance
        public string PlateOrContainer { get; internal set; }
    }
}
// This class represents a transport unit management model, which can be either a lorry or a container.

