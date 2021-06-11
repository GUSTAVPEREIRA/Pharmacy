using Pharmacy.DTO.Products;
using System.Collections.Generic;

namespace Pharmacy.Services.IServices.Products
{
    public interface IProductService
    {
        public ProductDTO CreateProduct(BaseProductDTO product);
        public ProductDTO UpdateProduct(ProductDTO product);
        public void DeleteProduct(int id);
        ProductDTO EnableOrDisableProduct(int id, bool enable);
        public ProductDTO GetProductById(int id);
        public List<ProductDTO> ListProductByParameters(string search, int id, int size, int page);
    }
}