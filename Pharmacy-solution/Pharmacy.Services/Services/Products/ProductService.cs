using AutoMapper;
using Pharmacy.DTO.Products;
using Pharmacy.Extensions.Exceptions;
using Pharmacy.Extensions.Queryable;
using Pharmacy.Infra.Repositories.IRepositories.Categories;
using Pharmacy.Infra.Repositories.IRepositories.Products;
using Pharmacy.Model.Products;
using Pharmacy.Services.IServices.Products;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace Pharmacy.Services.Services.Products
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, ICategoryRepository categoryRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public ProductDTO CreateProduct(BaseProductDTO productDTO)
        {
            var product = _mapper.Map<BaseProductDTO, Product>(productDTO);

            var category = _categoryRepository.FindById(product.CategoryId);

            if (category == null)
            {
                throw new APIException($"Categoria com o {product.CategoryId} não existe", HttpStatusCode.NotFound);
            }

            product.Category = category;
            _productRepository.Save(product);

            var newProduct = _mapper.Map<Product, ProductDTO>(product);

            return newProduct;
        }

        public void DeleteProduct(int id)
        {
            var product = _productRepository.FindById(id);
            CheckIfProductIsDisabled(product);

            _productRepository.Delete(product);
        }

        public ProductDTO EnableOrDisableProduct(int id, bool enable)
        {
            var product = _productRepository.FindById(id);

            if (product == null)
            {
                throw new APIException($"Não foi encontrado produco com o id {id}", HttpStatusCode.NotFound);
            }

            if (enable)
            {
                product.Enable();
            }
            else
            {
                product.Disable();
            }

            _productRepository.Updated(product);
            var productDTO = ConvertEntityToDTO(product);

            return productDTO;
        }

        public ProductDTO UpdateProduct(ProductDTO productDTO)
        {
            var product = ConvertDTOToEntity(productDTO);

            CheckIfProductIsDisabled(product);

            _productRepository.Updated(product);
            productDTO = ConvertEntityToDTO(product);

            return productDTO;
        }

        private Product ConvertDTOToEntity(ProductDTO productDTO)
        {
            return _mapper.Map<ProductDTO, Product>(productDTO);
        }

        private ProductDTO ConvertEntityToDTO(Product product)
        {
            return _mapper.Map<Product, ProductDTO>(product);
        }

        private void CheckIfProductIsDisabled(Product product)
        {
            if (product.DeletedAt.HasValue == true)
            {
                throw new APIException($"Produto {product.Id}-{product.Name} está desabilitado", HttpStatusCode.BadRequest);
            }
        }

        public ProductDTO GetProductById(int id)
        {
            var product = _productRepository.FindById(id);

            if (product == null)
            {
                throw new APIException($"Não existe produco com o id {id}", HttpStatusCode.NotFound);
            }

            var productDTO = ConvertEntityToDTO(product);

            return productDTO;
        }

        public List<ProductDTO> ListProductByParameters(string search, int id, int size, int page)
        {
            var queryable = _productRepository.GetAll();

            if (!string.IsNullOrEmpty(search))
            {
                queryable = queryable.Where(w => w.Name.Contains(search));
            }

            if (id != 0)
            {
                queryable = queryable.Where(w => w.Id == id);
            }

            var paginatedList = new PaginatedList<Product>(queryable, page, size);
            var list = paginatedList.AsQueryable().ToList();
            var productListDTO = _mapper.Map<List<Product>, List<ProductDTO>>(list);

            return productListDTO;
        }
    }
}