using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pharmacy.DTO.Products;
using Pharmacy.Extensions.Exceptions;
using Pharmacy.Services.IServices.Products;
using System.Collections.Generic;
using System.Net;

namespace Pharmacy.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="productService"></param>
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        /// <summary>
        /// 
        /// </summary>
        [HttpPost]
        [Route("create")]
        [Authorize]
        public ActionResult<ProductDTO> CreateProduct(BaseProductDTO baseProductDTO)
        {
            try
            {
                var produdct = _productService.CreateProduct(baseProductDTO);

                return new OkObjectResult(new
                {
                    Message = "Produto criado!",
                    Code = HttpStatusCode.OK,
                    Result = produdct
                });
            }
            catch (APIException ex)
            {
                return new BadRequestObjectResult(new
                {
                    ex.Message,
                    Code = ex.StatusCode
                });
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [HttpPut]
        [Route("update")]
        [Authorize]
        public ActionResult<dynamic> UpdateProduct(ProductDTO productDTO)
        {
            try
            {
                var produdct = _productService.UpdateProduct(productDTO);

                return new OkObjectResult(new
                {
                    Message = "Produto criado!",
                    Code = HttpStatusCode.OK,
                    Result = produdct
                });
            }
            catch (APIException ex)
            {
                return new BadRequestObjectResult(new
                {
                    ex.Message,
                    Code = ex.StatusCode
                });
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [HttpDelete]
        [Route("delete")]
        [Authorize]
        public ActionResult<dynamic> DeleteProduct(int id)
        {
            try
            {
                _productService.DeleteProduct(id);

                return new OkObjectResult(new
                {
                    Message = $"Produto {id} deletado!",
                    Code = HttpStatusCode.OK
                });
            }
            catch (APIException ex)
            {
                return new BadRequestObjectResult(new
                {
                    ex.Message,
                    Code = ex.StatusCode
                });
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [HttpPost]
        [Route("disable")]
        [Authorize]
        public ActionResult<ProductDTO> DisableProduct(int id, bool enable = false)
        {
            try
            {
                var produdct = _productService.EnableOrDisableProduct(id, enable);
                var mensageAux = produdct.DeletedAt.HasValue == true ? "desabilitado!" : "habilitado!";

                return new OkObjectResult(new
                {
                    Message = $"Produto foi {mensageAux}!",
                    Code = HttpStatusCode.OK,
                    Result = produdct
                });
            }
            catch (APIException ex)
            {
                return new BadRequestObjectResult(new
                {
                    ex.Message,
                    Code = ex.StatusCode
                });
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("get")]
        [Authorize]
        public ActionResult<ProductDTO> GetProduct(int id)
        {
            try
            {
                var productDTO = _productService.GetProductById(id);

                return new OkObjectResult(new
                {
                    Message = "Produto encontrado!",
                    Code = HttpStatusCode.OK,
                    Result = productDTO
                });
            }
            catch (APIException ex)
            {
                return new BadRequestObjectResult(new
                {
                    ex.Message,
                    Code = ex.StatusCode
                });
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="page"></param>
        /// <param name="size"></param>
        /// <param name="search"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("list")]
        [Authorize]
        public ActionResult<List<ProductDTO>> GetListProduct(int page, int size, string search, int id)
        {
            try
            {
                var productsList = _productService.ListProductByParameters(search, id, size, page);

                return new OkObjectResult(new
                {
                    Message = "Lista de produtos",
                    Code = HttpStatusCode.OK,
                    Result = productsList
                });
            }
            catch (APIException ex)
            {
                return new BadRequestObjectResult(new
                {
                    ex.Message,
                    Code = ex.StatusCode
                });
            }
        }
    }
}