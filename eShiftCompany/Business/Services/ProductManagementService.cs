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
    public class ProductManagementService : IProductManagementService
    {
        private readonly IProductManagementRepository _repository;

        public ProductManagementService(IProductManagementRepository repository)
        {
            _repository = repository;
        }

        public void AddProduct(ProductManagementModel product) => _repository.AddProduct(product);

        public void UpdateProduct(ProductManagementModel product) => _repository.UpdateProduct(product);

        public void DeleteProduct(int productId) => _repository.DeleteProduct(productId);

        public ProductManagementModel GetProductById(int productId) => _repository.GetProductById(productId);

        public List<ProductManagementModel> GetAllProducts() => _repository.GetAllProducts();

        public List<int> GetAllProductIds() => _repository.GetAllProductIds();
    }
}
