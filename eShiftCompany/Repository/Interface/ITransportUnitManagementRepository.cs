using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eShiftCompany.Models;

namespace eShiftCompany.Repository.Interface
{
    public interface ITransportUnitManagementRepository
    {
        void Add(TransportUnitManagementModel unit);
        void Update(TransportUnitManagementModel unit);
        void Delete(string type, int id);
        TransportUnitManagementModel GetById(string type, int id);
        List<TransportUnitManagementModel> GetAll(string type);
        void AddLorry(TransportUnitManagementModel model);
        object GetAllLorries();
    }
}
