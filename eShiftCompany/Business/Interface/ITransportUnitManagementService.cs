using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eShiftCompany.Models;

namespace eShiftCompany.Business.Interface
{
    public interface ITransportUnitManagementService
    {
        List<TransportUnitManagementModel> GetAllLorries();
        List<TransportUnitManagementModel> GetAllContainers();

        void AddLorry(TransportUnitManagementModel model);
        void AddContainer(TransportUnitManagementModel model);

        TransportUnitManagementModel GetLorryById(int id);
        TransportUnitManagementModel GetContainerById(int id);

        void UpdateLorry(TransportUnitManagementModel model);
        void UpdateContainer(TransportUnitManagementModel model);

        void DeleteLorry(int id);
        void DeleteContainer(int id);


    }
}
