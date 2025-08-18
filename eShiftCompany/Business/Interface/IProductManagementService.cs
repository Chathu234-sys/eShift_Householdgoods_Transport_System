using eShiftCompany.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShiftCompany.Business.Interface
{
    public interface IProductManagementService
    {
        void AddProduct(ProductManagementModel product);
        void UpdateProduct(ProductManagementModel product);
        void DeleteProduct(int productId);
        ProductManagementModel GetProductById(int productId);
        List<ProductManagementModel> GetAllProducts();
        List<int> GetAllProductIds();
    }
}
