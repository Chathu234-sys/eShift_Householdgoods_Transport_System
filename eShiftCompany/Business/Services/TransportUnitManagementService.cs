using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eShiftCompany.Business.Interface;
using eShiftCompany.Models;
using eShiftCompany.Repository.Interface;

namespace eShiftCompany.Business.Services
{
    public class TransportUnitManagementService : ITransportUnitManagementService
    {
        private readonly ITransportUnitManagementRepository _repository;

        public TransportUnitManagementService(ITransportUnitManagementRepository repository)
        {
            _repository = repository;
        }

        public void AddUnit(TransportUnitManagementModel unit)
        {
            _repository.Add(unit);
        }

        public void UpdateUnit(TransportUnitManagementModel unit)
        {
            _repository.Update(unit);
        }

        public void DeleteUnit(string type, int id)
        {
            _repository.Delete(type, id);
        }

        public TransportUnitManagementModel GetById(string type, int id)
        {
            return _repository.GetById(type, id);
        }
        public void AddLorry(TransportUnitManagementModel model)
        {
            model.Type = "Lorry";
            _repository.Add(model);
        }
        public List<TransportUnitManagementModel> GetAllLorries()
        {
            return _repository.GetAll("Lorry");
        }

        public List<TransportUnitManagementModel> GetAllContainers()
        {
            return _repository.GetAll("Container");
        }

        public void AddContainer(TransportUnitManagementModel model)
        {
            model.Type = "Container";
            _repository.Add(model);
        }

        public TransportUnitManagementModel GetLorryById(int id)
        {
            return _repository.GetById("Lorry", id);
        }

        public TransportUnitManagementModel GetContainerById(int id)
        {
            return _repository.GetById("Container", id);
        }

        public void UpdateLorry(TransportUnitManagementModel model)
        {
            model.Type = "Lorry";
            _repository.Update(model);
        }

        public void UpdateContainer(TransportUnitManagementModel model)
        {
            model.Type = "Container";
            _repository.Update(model);
        }

        public void DeleteLorry(int id)
        {
            _repository.Delete("Lorry", id);
        }

        public void DeleteContainer(int id)
        {
            _repository.Delete("Container", id);
        }


    }
}
